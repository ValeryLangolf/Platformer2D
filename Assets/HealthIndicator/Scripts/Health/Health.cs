using System;
using UnityEngine;

namespace MyIndicatorHealth
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        [SerializeField] private float _currentValue;

        public float MaxValue => _maxValue;

        public float Value => _currentValue;

        public event Action<float> ValueChanged;
        public event Action Damage;

        private void Start()
        {
            ValueChanged?.Invoke(Value);
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(string.Format(ExceptionData.Params.ValueMustBeGreaterZero, damage));

            _currentValue -= damage;

            if (_currentValue < 0)
                _currentValue = 0;

            Damage?.Invoke();
            ValueChanged?.Invoke(Value);
        }

        public void TakeHeal(float heal)
        {
            if (heal <= 0)
                throw new ArgumentOutOfRangeException(string.Format(ExceptionData.Params.ValueMustBeGreaterZero, heal));

            _currentValue += heal;

            if (_currentValue > MaxValue)
                _currentValue = MaxValue;

            ValueChanged?.Invoke(_currentValue);
        }
    }
}