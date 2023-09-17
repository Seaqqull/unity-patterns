using Creational.Builder.Health;
using Creational.Builder.Movement;

namespace Creational.Builder
{
    public abstract class EntityBuilderSO : UnityEngine.ScriptableObject
    {
        public abstract void Reset();

        public abstract void AddHealth(HealthType type);
        public abstract void AddMovement(MovementType type);

        public abstract IEntity GetResult();
    }
}