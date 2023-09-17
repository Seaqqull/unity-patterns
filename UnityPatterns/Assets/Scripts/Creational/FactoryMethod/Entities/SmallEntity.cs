using UnityEngine;

namespace Creational.FactoryMethod
{
    public class SmallEntity : MonoBehaviour, IEntity
    {
        public GameObject Object { get; private set; }
        
        private void Awake()
        {
            Object = gameObject;
            transform.localScale *= 0.5f;
        }
    }
}