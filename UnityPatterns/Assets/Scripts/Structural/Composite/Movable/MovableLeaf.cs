using System.Collections;
using UnityEngine;
using System;


namespace Structural.Composite.Movable
{
    public class MovableLeaf : MovableEntity
    {
        [SerializeField] private bool _instantMovement;
        [SerializeField] private float _movementSpeed;

        private Coroutine _movementCoroutine;

        private Vector3 _desiredPosition;
        private float _movementDistance;
        private float _movementProgress;
        private Vector3 _startPosition;
        private Vector3 _staticShift;
        private float _movementTime;

        public override event Action<Vector3> PositionChanged;

        protected override void Awake()
        {
            base.Awake();

            _staticShift = _transform.localPosition;
        }


        private IEnumerator MoveRoutine()
        {
            while (_movementProgress < _movementTime)
            {
                _movementProgress += (_movementSpeed * Time.deltaTime);
                var currentShift = Vector3.Lerp(_startPosition, _desiredPosition, _movementProgress / _movementTime);
                _transform.localPosition = _staticShift + currentShift;
                
                PositionChanged?.Invoke(currentShift);
                
                yield return null;
            }

            _movementCoroutine = null;
        }

        private void UpdateDesiredPosition(Vector3 positionShift)
        {
            _startPosition = _transform.localPosition - _staticShift;
            _desiredPosition = positionShift;
            
            var movementStep = (_desiredPosition - _startPosition);
            _movementDistance = movementStep.magnitude;
            
            _movementTime = _movementDistance / _movementSpeed;
            _movementProgress = 0.0f;
        }


        public override void Move(Vector3 shift)
        {
            if (_instantMovement)
            {
                _transform.localPosition = _staticShift + shift;
                return;
            }

            UpdateDesiredPosition(shift);
            if (_movementCoroutine == null)
                _movementCoroutine = StartCoroutine(MoveRoutine());
        }

        public override void SetParent(IMovableEntity entity)
        {
            entity.PositionChanged += Move;
        }
    }
}