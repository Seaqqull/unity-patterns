namespace Creational.AbstractFactory
{
    public abstract class EntityFabricSO : UnityEngine.ScriptableObject
    {
        public abstract IFirstEntity CreateFirst();
        public abstract ISecondEntity CreateSecond();
    }
}