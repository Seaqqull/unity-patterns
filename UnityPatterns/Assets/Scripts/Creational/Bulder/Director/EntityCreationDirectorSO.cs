using UnityEngine;

namespace Creational.Builder.Director
{
    public abstract class EntityCreationDirectorSO : ScriptableObject
    {
        public abstract IEntity CreateEntity();
        public abstract IEntity CreateEntity(EntityBuilderSO builder);

        public abstract IEntity CreateFixedEntity();
        public abstract IEntity CreateFixedEntity(EntityBuilderSO builder);
    }
}