using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth
{
    public class HealthBarSmoothView : HealthBarSmoothBase
    {
        [SerializeField] private Image _fill;

        protected override Image GetTargetImage(float target) => _fill;
    }
}