using UnityEngine;

namespace Creational.FactoryMethod
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private EntityFabricSO _first;
        [SerializeField] private EntityFabricSO _second;
        [Space] 
        [SerializeField] private Vector3 _position;

        private IEntity _spawnedEntity;
        
        public void SpawnFirstEntity()
        {
            if (_spawnedEntity != null)
                Destroy(_spawnedEntity.Object);
            _spawnedEntity = _first.Create(_position);
        }
        
        public void SpawnSecondEntity()
        {
            if (_spawnedEntity != null)
                Destroy(_spawnedEntity.Object);
            _spawnedEntity = _second.Create(_position);
        }
    }
}