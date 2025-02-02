using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth
{
    public class HealthBarSmooth2View : HealthBarSmoothBase
    {
        [SerializeField] private Image _fillBackround;
        [SerializeField] private Image _fill;
        [SerializeField] private Color _damage;
        [SerializeField] private Color _heal;

        protected override Image GetTargetImage(float target)
        {
            if (target < _fill.fillAmount)
            {
                _fill.fillAmount = target;
                _fillBackround.color = _damage;

                return _fillBackround;
            }
            else
            {
                _fillBackround.fillAmount = target;
                _fillBackround.color = _heal;

                return _fill;
            }
        }
    }
}