using UnityEngine;


namespace UnityPatterns.Pooling.Implementation
{
    public class PoolableObject : MonoBehaviour, IPoolable
    {
        public float upForce = 1;
        public float sideForce = 1;
        public float lifeTime = 10;

        private Pooler _poolController;

        public Pooler Pooler { get => _poolController; set => _poolController = value; }

        // This type of object always initialized
        public bool IsInitializationBuilt => true;


        private void Die()
        {
            PoolIn();
        }


        public void PoolIn()
        {
            gameObject.SetActive(false);

            Pooler.AddToPool(gameObject);
        }

        public void PoolOut()
        {
            float xForce = Random.Range(-sideForce, sideForce);
            float yForce = Random.Range(upForce / 2f, upForce);
            float zForce = Random.Range(-sideForce, sideForce);

            Vector3 force = new Vector3(xForce, yForce, zForce);
            GetComponent<Rigidbody>().velocity = force;

            Invoke("Die", lifeTime);
        }

        public void PoolInitialize()
        {
            // Nothing to do here
        }

        public void BuildInitialization()
        {
            // Nothing to do here
        }
    }
}
