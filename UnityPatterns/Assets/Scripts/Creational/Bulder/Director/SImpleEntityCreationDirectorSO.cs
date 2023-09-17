using Creational.Builder.Health;
using Creational.Builder.Movement;
using UnityEngine;

namespace Creational.Builder.Director
{
    [CreateAssetMenu(fileName = "SImpleEntityCreationDirector", menuName = "Creational/Builder/SImpleEntityCreationDirector", order = 0)]
    public class SImpleEntityCreationDirectorSO : EntityCreationDirectorSO
    {
        [SerializeField] private EntityBuilderSO _builder;


        public override IEntity CreateEntity()
        {
            _builder.Reset();
            _builder.AddHealth(HealthType.Interactive);
            _builder.AddMovement(MovementType.Dynamic);

            return _builder.GetResult();
        }

        public override IEntity CreateEntity(EntityBuilderSO builder)
        {
            builder.Reset();
            builder.AddHealth(HealthType.Interactive);
            builder.AddMovement(MovementType.Dynamic);

            return builder.GetResult();
        }

        public override IEntity CreateFixedEntity()
        {
            _builder.Reset();
            _builder.AddHealth(HealthType.None);
            _builder.AddMovement(MovementType.Static);

            return _builder.GetResult();
        }

        public override IEntity CreateFixedEntity(EntityBuilderSO builder)
        {
            builder.Reset();
            builder.AddHealth(HealthType.None);
            builder.AddMovement(MovementType.Static);

            return builder.GetResult();
        }
    }
}