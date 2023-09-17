using UnityEngine;

namespace Creational.Builder
{
    public class Entity : MonoBehaviour, IEntity
    {
        public Movement.Movement Movement { get; set; }
        public Health.Health Health { get; set; }
        public GameObject Object { get; private set; }


        private void Awake()
        {
            Object = gameObject;
        }
    }
}