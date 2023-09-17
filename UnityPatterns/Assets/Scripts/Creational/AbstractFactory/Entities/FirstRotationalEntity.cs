using General;
using UnityEngine;

namespace Creational.AbstractFactory
{
    public class FirstRotationalEntity : MonoBehaviour, IFirstEntity
    {
        private RandomRotator _rotator;
        
        public GameObject Object { get; private set; }

        public float Speed
        {
            get => _rotator.RotationSpeed;
            set => _rotator.RotationSpeed = value;
        }
        
        
        private void Awake()
        {
            Object = gameObject;

            _rotator = Object.AddComponent<RandomRotator>();
        }


        public void ShowMessage(string message)
        {
            Debug.LogError($"First entity [Rotational]: {message}");
        }
    }
}