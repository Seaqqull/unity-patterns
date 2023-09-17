using General;
using UnityEngine;

namespace Creational.AbstractFactory
{
    public class SecondMovingEntity : MonoBehaviour, ISecondEntity
    {
        private RandomTranslatorBetween _translator;
        
        public GameObject Object { get; private set; }

        public float Speed
        {
            get => _translator.Speed;
            set => _translator.Speed = value;
        }


        private void Awake()
        {
            Object = gameObject;

            _translator = Object.AddComponent<RandomTranslatorBetween>();
        }


        public void ShowMessage(params string[] message)
        {
            Debug.LogError($"Second entity [Moving]: {string.Join("\n", message)}");
        }
    }
}