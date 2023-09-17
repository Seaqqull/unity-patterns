using UnityEngine;


namespace Creational.AbstractFactory
{
    [CreateAssetMenu(fileName = "FirstEntityFabric", menuName = "Creational/AbstractFactory/FirstEntityFabric", order = 0)]
    public class FirstEntityFabricSO : EntityFabricSO
    {
        [SerializeField] private GameObject _prefab;
        [Space]
        [SerializeField] private Vector3 _scaleFactor;
        [SerializeField] private float _speed;

        
        public override IFirstEntity CreateFirst()
        {
            var entityObject = Instantiate(_prefab);
            entityObject.transform.localScale = _scaleFactor;
            
            var entity = entityObject.AddComponent<FirstMovingEntity>();
            entity.Speed = _speed;

            return entity;
        }

        public override ISecondEntity CreateSecond()
        {
            var entityObject = Instantiate(_prefab);
            entityObject.transform.localScale = _scaleFactor;
            
            var entity = entityObject.AddComponent<SecondMovingEntity>();
            entity.Speed = _speed;

            return entity;
        }
    }
}