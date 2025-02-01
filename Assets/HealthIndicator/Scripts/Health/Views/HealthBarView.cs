using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth
{
    public class HealthBarView : HealthView
    {
        [SerializeField] private Image _fill;

        public override void UpdateHealth(float currentValue, float maxValue)
        {
            _fill.fillAmount = currentValue / maxValue;
        }
    }
}