using UnityEngine;

namespace Creational.Builder.Movement
{
    public class DynamicMovement : Movement
    {
        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
        }
        

        public override void Move(Vector3 position)
        {
            _transform.position += position;
        }
    }
}