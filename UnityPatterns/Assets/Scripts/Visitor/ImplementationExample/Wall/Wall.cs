using UnityEngine;


namespace UnityPatterns.Visitor.Implementation
{
    [RequireComponent(typeof(Collider))]
    public class Wall : MonoBehaviour
    {
        protected Collider _collider;
        protected Data.WallHolder _holder;

        
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _holder = GetComponent<Data.WallHolder>();
        }

        public void OnTriggerEnter(Collider other)
        {
            var affectedEntity = other.gameObject;

            if (affectedEntity.TryGetComponent<Data.Bullet>(out var affectedBullet))
            {
                affectedBullet.InterfareWall(_holder);
            }
        }
    }
}
