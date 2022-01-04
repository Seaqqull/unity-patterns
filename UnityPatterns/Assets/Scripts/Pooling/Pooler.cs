using System.Collections.Generic;
using UnityEngine;


namespace UnityPatterns.Pooling
{
    public abstract class Pooler : MonoBehaviour
    {
        [SerializeField] protected int _idGameObject;


        [SerializeField] protected Transform _spawnPosition;
        [SerializeField] protected GameObject _spawnObject;

        [SerializeField] protected int _poolAmount = 1;
        [SerializeField] protected int _expansionAmount = 1;
        [SerializeField] protected int _reductionAmount = 1;

        protected Queue<GameObject> _objectsToPool;
        protected GameObject _spawned;
        protected GameObject _queue;

        public int GameObjectId
        {
            get { return this._idGameObject; }
        }



        public virtual void Awake()
        {
            if ((_spawnObject == null) ||
                (_spawnObject.GetComponent<IPoolable>()) == null)
            {
#if UNITY_EDITOR
                Debug.LogError("Poolable object doesn't have IPoolable member or object is empty", gameObject);
#endif
                return;
            }
            if (_spawnPosition == null) _spawnPosition = transform;

            _spawned = new GameObject("Spawned");
            _queue = new GameObject("Queue");

            _spawned.transform.parent = transform;
            _queue.transform.parent = transform;

            _objectsToPool = new Queue<GameObject>();

            PoolExtend(_poolAmount);
        }


        /// <summary> 
        /// Instantiates object and adds it too pool
        /// </summary>
        protected virtual void PoolCreate()
        {
            GameObject dummyIn = Instantiate(_spawnObject);

            if (dummyIn.TryGetComponent<IPoolable>(out IPoolable poolableDummy))
            {
                poolableDummy.Pooler = this;
                if (!poolableDummy.IsInitializationBuilt)
                    poolableDummy.BuildInitialization();
            }

            dummyIn.transform.parent = _queue.transform;
            dummyIn.SetActive(false);

            _objectsToPool.Enqueue(dummyIn);
        }

        /// <summary>
        /// Instantiates [amount] of given objects and inserts into the queue
        /// </summary>
        /// <param name="amount">Amount of items to be instantiated and inserted into the queue</param>
        protected void PoolExtend(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                PoolCreate();
            }
        }

        /// <summary>
        /// Pools object
        /// </summary>
        protected virtual GameObject PoolOut()
        {
            GameObject dummyOut = _objectsToPool.Dequeue();

            var dummyTransform = dummyOut.transform;
            dummyTransform.position = _spawnPosition.position;
            dummyTransform.parent = _spawned.transform;

            dummyOut.SetActive(true);

            return dummyOut;
        }

        /// <summary>
        /// Adds object to pool
        /// </summary>
        /// <param name="dummyIn">Object to be added</param>
        protected virtual void PoolIn(GameObject dummyIn)
        {
            dummyIn.SetActive(false);

            var dummyTransform = dummyIn.transform;
            dummyTransform.parent = _queue.transform;
            dummyTransform.position = Vector3.zero;

            _objectsToPool.Enqueue(dummyIn);
        }


        public GameObject Pool()
        {
            if (_spawnObject == null) return null;

            if (_objectsToPool.Count == 0)
                PoolExtend(_expansionAmount);

            GameObject dummyOut = PoolOut();
            if (dummyOut.TryGetComponent<IPoolable>(out IPoolable poolableDummy))
            {
                poolableDummy.PoolInitialize();
                poolableDummy.PoolOut();
            }

            return dummyOut;
        }

        public void AddToPool(GameObject dummyIn)
        {
            int deletionAmount = _reductionAmount - 1;

            if (_objectsToPool.Count >= (_poolAmount + deletionAmount))
            {
                for (int i = 0; i < deletionAmount; i++)
                {
                    Destroy(_objectsToPool.Dequeue());
                }
                Destroy(dummyIn);
                return;
            }

            PoolIn(dummyIn);
        }
    }
}
