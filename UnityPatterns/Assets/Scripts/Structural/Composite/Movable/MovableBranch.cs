using UnityEngine;

namespace Structural.Composite.Movable
{
    public class MovableBranch : MovableLeaf
    {
        [SerializeField] private MovableEntity[] _children;

        protected override void Awake()
        {
            base.Awake();

            foreach (var child in _children)
                PositionChanged += child.Move;
        }
    }
}