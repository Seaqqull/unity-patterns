using System;
using UnityEngine;

namespace Structural.Composite.Movable
{
    public class MovableComposite : MovableEntity
    {
        [SerializeField] private MovableEntity _parent;
        [SerializeField] private MovableEntity[] _children;

        private IMovableEntity _parentEntity;
        
        public override event Action<Vector3> PositionChanged;


        protected override void Awake()
        {
            base.Awake();

            SetParent(_parent);
        }

        public override void Move(Vector3 shift)
        {
            foreach (var child in _children)
                child.Move(shift);
        }

        public override void SetParent(IMovableEntity entity)
        {
            _parentEntity = entity;
            _parent.PositionChanged += Move;
        }
    }
}