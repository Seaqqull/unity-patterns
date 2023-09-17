using UnityEngine;
using System;


namespace Creational.Builder.Health
{
    public abstract class Health : MonoBehaviour
    {
        public event Action OnHealthMinus;
        public event Action OnHealthPlus;

        public float Percent
        {
            get { return 1.0f * Value / MaxValue; }
        }
        public abstract int MaxValue { get; }
        public abstract bool IsZero { get; }
        public abstract int Value { get; }


        protected virtual void Awake() { }
        protected virtual void Start() { }

        private void OnDestroy()
        {
            OnHealthMinus = null;
            OnHealthPlus = null;
        }


        public virtual void ResetHealth()
        {
            ResetHealth(MaxValue);
        }

        public virtual void ModifyHealth(int amount)
        {
            if (amount > 0)
                OnHealthMinus?.Invoke();
            else if (amount < 0)
                OnHealthPlus?.Invoke();
        }


        public abstract void ResetHealth(int amount);
    }
}