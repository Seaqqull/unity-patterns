using UnityEngine;


namespace Creational.Builder
{
    public interface IEntity
    {
        public Movement.Movement Movement { get; set; }
        public Health.Health Health { get; set; }
        public GameObject Object { get; }
    }
}