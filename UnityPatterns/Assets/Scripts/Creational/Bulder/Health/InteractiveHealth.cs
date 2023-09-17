using UnityEngine.Events;
using UnityEngine;
using System;


namespace Creational.Builder.Health
{
    public class InteractiveHealth : Health
    {
        [Serializable]
        public class HealthUpdateEvent : UnityEvent<float> { }


#pragma warning disable CS0414, CS0649
        [SerializeField] private HealthUpdateEvent _onHealthChanged;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _health;
#pragma warning restore CS0414, CS0649

        public event UnityAction<float> HealthEvent;

        public override int MaxValue
        {
            get { return this._maxHealth; }
        }
        public override bool IsZero
        {
            get { return this._health == 0; }
        }
        public override int Value
        {
            get { return this._health; }
        }


        protected override void Awake()
        {
            if (_health > _maxHealth) _health = _maxHealth;
        }

        protected override void Start()
        {
            base.Start();

            ModifyHealth(0);
        }


        public override void ResetHealth(int amount)
        {
            _health = (amount > _maxHealth) ? _maxHealth : amount;

            HealthEvent.Invoke(Percent);
            _onHealthChanged.Invoke(Percent);
        }

        public override void ModifyHealth(int amount)
        {
            _health = (_health < amount) ? 0 : _health - amount;

            HealthEvent?.Invoke(Percent);
            _onHealthChanged?.Invoke(Percent);

            base.ModifyHealth(amount);
        }
    }
}