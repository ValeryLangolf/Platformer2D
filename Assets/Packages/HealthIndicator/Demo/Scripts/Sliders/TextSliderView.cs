using TMPro;
using UnityEngine;

namespace MyIndicatorHealth.Demo
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextSliderView : MonoBehaviour
    {
        private const string F2 = nameof(F2);

        [SerializeField] private HandlerChangeValueSlider _slider;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _slider.ValueChanged += HandleChange;
        }

        private void OnDisable()
        {
            _slider.ValueChanged += HandleChange;
        }

        private void HandleChange(float value)
        {
            _text.text = value.ToString(F2);
        }
    }
}