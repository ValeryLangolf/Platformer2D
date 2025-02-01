using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth.Demo
{
    public class InformerActionButton : MonoBehaviour
    {
        [SerializeField] private float value;

        private Button _button;

        public event Action<float> Clicked;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke(value);
        }
    }
}