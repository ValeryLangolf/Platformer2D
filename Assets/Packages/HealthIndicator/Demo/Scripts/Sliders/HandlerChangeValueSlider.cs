using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth.Demo
{
    [RequireComponent(typeof(Slider))]
    public class HandlerChangeValueSlider : MonoBehaviour
    {
        private Slider _slider;

        public event Action<float> ValueChanged;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            HandleChange(_slider.value);
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(HandleChange);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(HandleChange);
        }

        private void HandleChange(float value)
        {
            ValueChanged?.Invoke(value);
        }
    }
}