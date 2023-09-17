using UnityEngine;

namespace Creational.FactoryMethod
{
    public class SimpleEntity : MonoBehaviour, IEntity
    {
        public GameObject Object { get; private set; }

        private void Awake()
        {
            Object = gameObject;
        }
    }
}