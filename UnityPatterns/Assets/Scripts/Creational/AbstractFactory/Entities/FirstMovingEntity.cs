using System;
using General;
using UnityEngine;


namespace Creational.AbstractFactory
{
    public class FirstMovingEntity : MonoBehaviour, IFirstEntity
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

        public void ShowMessage(string message)
        {
            Debug.LogError($"First entity [Moving]: {message}");
        }
    }
}