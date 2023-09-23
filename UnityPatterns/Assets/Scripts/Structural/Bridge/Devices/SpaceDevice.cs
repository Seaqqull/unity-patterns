using UnityEngine;


namespace Structural.Bridge
{
    public class SpaceDevice : Device
    {
        [SerializeField] private Vector2 _horizontalBounds;
        [SerializeField] private Vector2 _verticalBounds;
        [Space]
        [SerializeField] private Vector2 _movementSpeed;

        private Vector3 _initialPosition;
        private Vector2 _positionShift;
        private Transform _transform;

        
        private void Awake()
        {
            _transform = transform;
            _initialPosition = _transform.localPosition;
        }
        
        
        private bool UpdatePositionShift(ref float current, float shift, Vector2 bounds)
        {
            if (current + shift < bounds.x || current + shift > bounds.y)
                return false;
            
            current += shift;
            if (current < bounds.x)
                current = bounds.x;
            else if (current > bounds.y)
                current = bounds.y;

            return true;
        }

        private void UpdatePosition()
        {
            var shiftedPosition = new Vector2(
                _initialPosition.x + _positionShift.x,
                _initialPosition.y + _positionShift.y);
            _transform.localPosition = new Vector3(shiftedPosition.x, _transform.localPosition.y, shiftedPosition.y);
        }


        public override void MoveUp()
        {
            if (UpdatePositionShift(ref _positionShift.y, _movementSpeed.y, _verticalBounds))
                UpdatePosition();
        }

        public override void MoveDown()
        {
            if (UpdatePositionShift(ref _positionShift.y, -_movementSpeed.y, _verticalBounds))
                UpdatePosition();
        }

        public override void MoveLeft()
        {
            if (UpdatePositionShift(ref _positionShift.x, -_movementSpeed.x, _horizontalBounds))
                UpdatePosition();
        }

        public override void MoveRight()
        {
            if (UpdatePositionShift(ref _positionShift.x, _movementSpeed.x, _horizontalBounds))
                UpdatePosition();
        }

        public override void ResetPosition()
        {
            if (_positionShift == Vector2.zero)
                return;

            _positionShift = Vector2.zero;
            UpdatePosition();
        }
    }
}