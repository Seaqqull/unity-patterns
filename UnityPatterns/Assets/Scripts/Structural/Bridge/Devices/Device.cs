using UnityEngine;

namespace Structural.Bridge
{
    public abstract class Device : MonoBehaviour, IDevice
    {
        public abstract void MoveUp();
        public abstract void MoveDown();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void ResetPosition();
    }
}