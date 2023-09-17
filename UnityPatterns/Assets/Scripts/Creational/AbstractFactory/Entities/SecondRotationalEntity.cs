using General;
using UnityEngine;

namespace Creational.AbstractFactory
{
    public class SecondRotationalEntity : MonoBehaviour, ISecondEntity
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


        public void ShowMessage(params string[] message)
        {
            Debug.LogError($"Second entity [Rotational]: {string.Join("\n", message)}");
        }
    }
}