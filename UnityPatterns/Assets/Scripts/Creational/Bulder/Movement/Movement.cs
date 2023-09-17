using UnityEngine;


namespace Creational.Builder.Movement
{
    public abstract class Movement : MonoBehaviour
    {
        public float Speed { get; set; }

        public abstract void Move(Vector3 position);
    }
}