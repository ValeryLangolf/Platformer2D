using System.Text;
using TMPro;
using UnityEngine;

namespace MyIndicatorHealth
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HealthTextView : HealthView
    {
        private TextMeshProUGUI _text;
        private StringBuilder _stringBuilder = new();

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public override void UpdateHealth(float currentValue, float maxValue)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(Mathf.FloorToInt(currentValue));
            _stringBuilder.Append("/");
            _stringBuilder.Append(Mathf.FloorToInt(maxValue));
            _text.text = _stringBuilder.ToString();
        }
    }
}