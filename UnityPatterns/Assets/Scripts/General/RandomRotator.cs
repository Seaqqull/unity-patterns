using UnityEngine;

namespace General
{
    public class RandomRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private Vector3 _rndRotation;
        private Transform _transform;

        public float RotationSpeed
        {
            get => _rotationSpeed;
            set => _rotationSpeed = value;
        }

        
        private void Awake()
        {
            _rndRotation = Random.onUnitSphere;
            _transform = transform;
        }

        private void Update()
        {
            _transform.Rotate(_rndRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}