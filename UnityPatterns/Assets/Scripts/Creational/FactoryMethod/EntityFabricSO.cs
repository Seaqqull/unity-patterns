using UnityEngine;

namespace Creational.FactoryMethod
{
    public abstract class EntityFabricSO : UnityEngine.ScriptableObject
    {
        public abstract IEntity Create(Vector3 position);
    }
}