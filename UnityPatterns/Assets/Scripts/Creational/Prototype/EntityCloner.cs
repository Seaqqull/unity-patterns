using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Creational.Prototype
{
    public class EntityCloner : MonoBehaviour, IPrototype<Entity>
    {
        private enum AxisType { X, Y, Z }
        
        [Header("Ui")] 
        [SerializeField] private TMP_InputField _rotationX;
        [SerializeField] private TMP_InputField _rotationY;
        [SerializeField] private TMP_InputField _rotationZ;
        [Space]
        [SerializeField] private TMP_InputField _speed;
        [Space]
        [SerializeField] private Entity _prefab;
        [Space]
        [SerializeField] private Transform _originPosition;
        [SerializeField] private Transform[] _copiesPositions;

        private List<Entity> _copies = new();
        private Entity _origin;


        private void Awake()
        {
            _origin = Instantiate(_prefab, _originPosition);
            
            _rotationX.text = _origin.RotationDirection.x.ToString();
            _rotationY.text = _origin.RotationDirection.y.ToString();
            _rotationZ.text = _origin.RotationDirection.z.ToString();
            _speed.text = _origin.RotationSpeed.ToString();
            
            _rotationX.onValueChanged.AddListener((str) => UpdateRotation(str, AxisType.X));
            _rotationY.onValueChanged.AddListener((str) => UpdateRotation(str, AxisType.Y));
            _rotationZ.onValueChanged.AddListener((str) => UpdateRotation(str, AxisType.Z));
            _speed.onValueChanged.AddListener((str) =>
            {
                if (!float.TryParse(str, out var speed))
                    speed = 1.0f;
                _origin.RotationSpeed = speed;
            });
        }


        private void UpdateRotation(string rotationValue, AxisType type)
        {
            if (!float.TryParse(rotationValue, out var newRotation))
                newRotation = 0.0f;

            switch (type)
            {
                case AxisType.X:
                    _origin.RotationDirection = new Vector3(
                        newRotation, 
                        _origin.RotationDirection.y,
                        _origin.RotationDirection.z).normalized;
                    break;
                case AxisType.Y:
                    _origin.RotationDirection = new Vector3(
                        _origin.RotationDirection.x, 
                        newRotation,
                        _origin.RotationDirection.z).normalized;
                    break;
                case AxisType.Z:
                    _origin.RotationDirection = new Vector3(
                        _origin.RotationDirection.x, 
                        _origin.RotationDirection.y,
                        newRotation).normalized;
                    break;
                default:
                    return;
            }
        }
        

        public void MakeCopy()
        {
            var newCopy = Clone();
            
            if (_copies.Count == _copiesPositions.Length)
            {
                Destroy(_copies[0].gameObject);
                
                for(var i = 1; i < _copies.Count; i++)
                {
                    _copies[i].Transform.parent = _copiesPositions[i - 1];
                    _copies[i].Transform.localPosition = Vector3.zero;
                }

                _copies.RemoveAt(0);
            }

            newCopy.Transform.SetParent(_copiesPositions[_copies.Count], true);
            newCopy.Transform.localPosition = Vector3.zero;

            _copies.Add(newCopy);
        }

        public Entity Clone()
        {
            return _origin.Clone();
        }
    }
}