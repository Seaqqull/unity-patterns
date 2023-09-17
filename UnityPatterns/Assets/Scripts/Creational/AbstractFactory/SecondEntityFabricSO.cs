using UnityEngine;


namespace Creational.AbstractFactory
{
    [CreateAssetMenu(fileName = "SecondEntityFabric", menuName = "Creational/AbstractFactory/SecondEntityFabric", order = 0)]
    public class SecondEntityFabricSO : EntityFabricSO
    {
        [SerializeField] private GameObject _prefab;
        [Space]
        [SerializeField] private Vector3 _scaleFactor;
        [SerializeField] private float _speed;
        
        
        public override IFirstEntity CreateFirst()
        {
            var entityObject = Instantiate(_prefab);
            entityObject.transform.localScale = _scaleFactor;
            
            var entity = entityObject.AddComponent<FirstRotationalEntity>();
            entity.Speed = _speed;

            return entity;
        }

        public override ISecondEntity CreateSecond()
        {
            var entityObject = Instantiate(_prefab);
            entityObject.transform.localScale = _scaleFactor;
            
            var entity = entityObject.AddComponent<SecondRotationalEntity>();
            entity.Speed = _speed;

            return entity;
        }
    }
}