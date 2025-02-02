using UnityEngine;

namespace MyIndicatorHealth
{
    public abstract class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.ValueChanged += HandleChange;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= HandleChange;
        }

        private void HandleChange(float health)
        {
            UpdateHealth(health, _health.MaxValue);
        }

        public abstract void UpdateHealth(float currentValue, float maxValue);
    }
}