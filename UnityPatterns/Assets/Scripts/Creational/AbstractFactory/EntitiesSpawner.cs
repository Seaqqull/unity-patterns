using UnityEngine;


namespace Creational.AbstractFactory
{
    public class EntitiesSpawner : MonoBehaviour
    {
        [SerializeField] private EntityFabricSO _firstFabric;
        [SerializeField] private EntityFabricSO _secondFabric;
        [Space] 
        [SerializeField] private Transform _firstPosition;
        [SerializeField] private Transform _secondPosition;

        private ISecondEntity _secondSpawnedEntity;
        private IFirstEntity _firstSpawnedEntity;


        private void ClearEntities()
        {
            if (_firstSpawnedEntity != null)
                Destroy(_firstSpawnedEntity.Object);
            if (_secondSpawnedEntity != null)
                Destroy(_secondSpawnedEntity.Object);
        }
        
        private void CreateEntities(EntityFabricSO fabric)
        {
            ClearEntities();

            _secondSpawnedEntity = fabric.CreateSecond();
            _firstSpawnedEntity = fabric.CreateFirst();
            

            _secondSpawnedEntity.Object.transform.position = _secondPosition.position;
            _firstSpawnedEntity.Object.transform.position = _firstPosition.position;
        }
        

        public void SpawnFirstEntities()
        {
            CreateEntities(_firstFabric);
        }
        
        public void SpawnSecondEntities()
        {
            CreateEntities(_secondFabric);
        }
    }
}