using UnityEngine;


namespace Creational.Prototype
{
    public class Entity : MonoBehaviour, IPrototype<Entity>
    {
        [field: SerializeField] public Vector3 RotationDirection { get; set; } = Vector3.up;
        [field: SerializeField] public float RotationSpeed { get; set; } = 1.0f;

        public Transform Transform { get; private set; }


        private void Awake()
        {
            Transform = transform;
        }

        private void Update()
        {
            Transform.Rotate(RotationDirection, RotationSpeed * Time.deltaTime);
        }


        public Entity Clone()
        {
            var copy = Instantiate(gameObject);
            var copyTransform = copy.transform;

            copyTransform.rotation = Transform.rotation;
            copyTransform.localScale = Transform.localScale;
            copyTransform.localPosition = Transform.localPosition;

            return copy.GetComponent<Entity>();
        }
    }
}