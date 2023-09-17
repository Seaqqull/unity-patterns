using UnityEngine;

namespace Creational.FactoryMethod
{
    [CreateAssetMenu(fileName = "SimpleEntityFabric", menuName = "Creational/FactoryMethod/SimpleEntityFabric", order = 0)]
    public class SimpleEntityFabricSO : EntityFabricSO
    {
        [SerializeField] private Vector3 _scaleFactor;
        [SerializeField] private GameObject _prefab;
        
        public override IEntity Create(Vector3 position)
        {
            var entityObject = Instantiate(_prefab, position, Quaternion.identity);
            entityObject.transform.localScale = _scaleFactor;
            
            return entityObject.AddComponent<SimpleEntity>();
        }
    }
}