using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;
using Creational.Builder.Movement;
using Creational.Builder.Health;
using UnityEngine;


namespace Creational.Builder
{
    [CreateAssetMenu(fileName = "SimpleEntityBuilder", menuName = "Creational/Builder/SimpleEntityBuilder", order = 0)]
    public class SimpleEntityBuilderSO : EntityBuilderSO
    {
        [SerializeField] private GameObject _prefab;
        
        private GameObject _instance;
        private IEntity _entity;


        public override void Reset()
        {
            _instance = Instantiate(_prefab);
            _entity = _instance.AddComponent<Entity>();
        }

        public override void AddHealth(HealthType type)
        {
            if (_instance.TryGetComponent<Health.Health>(out var _))
                return;

            switch (type)
            {
                case HealthType.None:
                    _instance.AddComponent<HealthNo>();
                    break;
                case HealthType.Interactive:
                    _instance.AddComponent<InteractiveHealth>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Inappropriate health type.");
            }
        }

        public override void AddMovement(MovementType type)
        {
            if (_instance.TryGetComponent<Movement.Movement>(out var health))
                return;

            switch (type)
            {
                case MovementType.Static:
                    _instance.AddComponent<StaticMovement>();
                    break;
                case MovementType.Dynamic:
                    _instance.AddComponent<DynamicMovement>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Inappropriate movement type.");
            }
        }

        public override IEntity GetResult()
        {
            return _entity;
        }
    }
}