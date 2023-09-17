using UnityEngine;
using Random = UnityEngine.Random;

namespace General
{
    public class RandomTranslatorBetween : MonoBehaviour
    {
        [SerializeField] private float _speed  =1.0f;

        private Transform _transform;

        private float _shiftProgress = 0.5f;
        private bool _isForwardTranslation;
        private Vector3 _initialPosition;
        private Vector3 _fromShift;
        private Vector3 _toShift;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        
        private void Awake()
        {
            _fromShift = Random.onUnitSphere;
            _toShift = Random.onUnitSphere;
            
            _transform = transform;
        }

        private void Start()
        {
            _initialPosition = _transform.position;
            _transform.localPosition = GetLerpTranslation();
        }

        private void Update()
        {
            _shiftProgress += ((_isForwardTranslation ? Time.deltaTime : -Time.deltaTime) * _speed);
            _shiftProgress = Mathf.Clamp01(_shiftProgress);

            _transform.localPosition = GetLerpTranslation();
            
            if (_shiftProgress == 0.0f || _shiftProgress >= 1.0f)
                _isForwardTranslation = !_isForwardTranslation;
        }

        private Vector3 GetLerpTranslation()
        {
            return _transform.localPosition = _initialPosition + Vector3.Lerp(_fromShift, _toShift, _shiftProgress);
        }
    }
}