using UnityEngine;

namespace MyIndicatorHealth.Demo
{
    public class TransmitterChangedHealth : MonoBehaviour
    {
        [SerializeField] private InformerActionButton _damageButton;
        [SerializeField] private InformerActionButton _healButton;
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _healButton.Clicked += OnTakeHeal;
            _damageButton.Clicked += OnTakeDamage;
        }

        private void OnDisable()
        {
            _healButton.Clicked -= OnTakeHeal;
            _damageButton.Clicked -= OnTakeDamage;
        }

        private void OnTakeDamage(float value)
        {
            _health.TakeDamage(value);
        }

        private void OnTakeHeal(float value)
        {
            _health.TakeHeal(value);
        }
    }
}