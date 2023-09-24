using System;
using UnityEngine;

namespace Structural.Composite.Movable
{
    public abstract class MovableEntity : MonoBehaviour, IMovableEntity
    {
        protected Transform _transform;

        public abstract event Action<Vector3> PositionChanged;

        public Vector3 CurrentPosition => _transform.localPosition;


        protected virtual void Awake()
        {
            _transform = transform;
        }

        public abstract void Move(Vector3 shift);
        public abstract void SetParent(IMovableEntity entity);
    }
}