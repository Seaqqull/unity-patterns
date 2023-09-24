using Structural.Composite.Movable;
using UnityEngine;

namespace Structural.Composite
{
    public class MovableController : MonoBehaviour
    {
        [SerializeField] private MovableEntity _entity;
        [Space]
        [SerializeField] private Vector2 _horizontalBounds;
        [SerializeField] private Vector2 _verticalBounds;
        [Space]
        [SerializeField] private Vector2 _movementSpeed;

        private Vector2 _positionShift;


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
            _entity.Move(new Vector3(_positionShift.x, 0.0f, _positionShift.y));
        }


        public void MoveUp()
        {
            if (UpdatePositionShift(ref _positionShift.y, _movementSpeed.y, _verticalBounds))
                UpdatePosition();
        }

        public void MoveDown()
        {
            if (UpdatePositionShift(ref _positionShift.y, -_movementSpeed.y, _verticalBounds))
                UpdatePosition();
        }

        public void MoveLeft()
        {
            if (UpdatePositionShift(ref _positionShift.x, -_movementSpeed.x, _horizontalBounds))
                UpdatePosition();
        }

        public void MoveRight()
        {
            if (UpdatePositionShift(ref _positionShift.x, _movementSpeed.x, _horizontalBounds))
                UpdatePosition();
        }

        public void ResetPosition()
        {
            if (_positionShift == Vector2.zero)
                return;

            _positionShift = Vector2.zero;
            UpdatePosition();
        }
    }
}