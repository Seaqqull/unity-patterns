using Creational.Builder.Director;
using UnityEngine;

namespace Creational.Builder
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private EntityBuilderSO _builder;
        [SerializeField] private EntityCreationDirectorSO _director;
        [Space] 
        [SerializeField] private Transform _entityTransform;

        private IEntity _entity;
        
        
        public void BuildFixedEntity()
        {
            if (_entity != null)
                Destroy(_entity.Object);

            _entity = _director.CreateFixedEntity();
            
            _entity.Object.transform.parent = _entityTransform;
            _entity.Object.transform.localPosition = Vector3.zero;
        }

        public void BuildOrdinalEntity()
        {
            if (_entity != null)
                Destroy(_entity.Object);

            _entity = _director.CreateEntity();
            
            _entity.Object.transform.parent = _entityTransform;
            _entity.Object.transform.localPosition = Vector3.zero;
        }
        
        public void BuildCustomFixedEntity()
        {
            if (_entity != null)
                Destroy(_entity.Object);

            _entity = _director.CreateFixedEntity(_builder);
            
            _entity.Object.transform.parent = _entityTransform;
            _entity.Object.transform.localPosition = Vector3.zero;
        }
        
        public void BuildCustomOrdinalEntity()
        {
            if (_entity != null)
                Destroy(_entity.Object);

            _entity = _director.CreateEntity(_builder);
            
            _entity.Object.transform.parent = _entityTransform;
            _entity.Object.transform.localPosition = Vector3.zero;
        }
    }
}