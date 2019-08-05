using System.Collections.Generic;
using UnityEngine;

public abstract class Pooler : MonoBehaviour
{
    [SerializeField] protected Transform _spawnPosition;
    [SerializeField] protected GameObject _spawnObject;

    [SerializeField] protected int _poolAmount = 1;
    [SerializeField] protected int _expansionAmount = 1;
    [SerializeField] protected int _reductionAmount = 1;

    protected Queue<GameObject> _objectsPool;
    protected GameObject _spawned;
    protected GameObject _queue;
    

    private void Awake()
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

        _objectsPool = new Queue<GameObject>();

        for (int i = 0; i < _poolAmount; i++)
        {
            PoolCreate();
        }
    }


    /// <summary> 
    /// Instantiate object and adds it too pool
    /// </summary>
    protected virtual void PoolCreate()
    {
        GameObject obj = Instantiate(_spawnObject);

        obj.GetComponent<IPoolable>().Pooler = this;
        obj.transform.parent = _queue.transform;        

        _objectsPool.Enqueue(obj);
    }

    /// <summary>
    /// Pools object
    /// </summary>
    protected virtual GameObject PoolOut()
    {        
        GameObject obj = _objectsPool.Dequeue();

        obj.transform.position = _spawnPosition.position;
        obj.transform.parent = _spawned.transform;        
        obj.SetActive(true);

        return obj;
    }

    /// <summary>
    /// Adds object to pool
    /// </summary>
    /// <param name="obj">Object to be added</param>
    protected virtual void PoolIn(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.parent = _queue.transform;

        _objectsPool.Enqueue(obj);
    }


    public GameObject Pool()
    {
        if (_spawnObject == null) return null;

        if (_objectsPool.Count == 0)
        {
            for (int i = 0; i < _expansionAmount; i++)
            {
                PoolCreate();
            }
        }

        return PoolOut();
    }

    public void AddToPool(GameObject obj)
    {
        if (_objectsPool.Count >= (_poolAmount + _reductionAmount))
        {
            for (int i = 0; i < _reductionAmount; i++)
            {
                Destroy(PoolOut());
            }
        }

        PoolIn(obj);
    }

}
