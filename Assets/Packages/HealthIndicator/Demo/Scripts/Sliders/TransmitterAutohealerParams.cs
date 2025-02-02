using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth.Demo
{
    public class TransmitterAutohealerParams : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Autohealer _autohealer;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private HandlerChangeValueSlider _delayTime;
        [SerializeField] private HandlerChangeValueSlider _rateTime;
        [SerializeField] private HandlerChangeValueSlider _valueHeal;

        private void Start()
        {
            OnHeal();
        }

        private void OnEnable()
        {
            _autohealer.Healed += OnTakeHeal;
            _toggle.onValueChanged.AddListener(HandleToggle);
            _delayTime.ValueChanged += HandleDelay;
            _rateTime.ValueChanged += HandleRate;
            _valueHeal.ValueChanged += HandleValueHeal;
            _health.Damage += OnHeal;
        }

        private void OnDisable()
        {
            _autohealer.Healed -= OnTakeHeal;
            _toggle.onValueChanged.RemoveListener(HandleToggle);
            _delayTime.ValueChanged -= HandleDelay;
            _rateTime.ValueChanged -= HandleRate;
            _valueHeal.ValueChanged -= HandleValueHeal;
            _health.Damage -= OnHeal;
        }

        private void OnTakeHeal(float value)
        {
            _health.TakeHeal(value);
        }

        private void HandleToggle(bool _)
        {
            OnHeal();
        }

        private void HandleDelay(float value)
        {
            _autohealer.SetDelay(value);
        }

        private void HandleRate(float value)
        {
            _autohealer.SetRate(value);
        }

        private void HandleValueHeal(float value)
        {
            _autohealer.SetHealingValue(value);
        }

        private void OnHeal()
        {
            if (_toggle.isOn)
                _autohealer.StartHealing();
            else
                _autohealer.StopHealing();
        }
    }
}