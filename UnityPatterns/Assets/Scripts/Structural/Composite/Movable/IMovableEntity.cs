using UnityEngine;
using System;

namespace Structural.Composite.Movable
{
    public interface IMovableEntity
    {
        event Action<Vector3> PositionChanged;
        
        Vector3 CurrentPosition { get; }

        void Move(Vector3 position);
        void SetParent(IMovableEntity entity);
    }
}