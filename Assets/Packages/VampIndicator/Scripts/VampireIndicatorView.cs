using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace VampireIndicator
{
    [RequireComponent(typeof(Button))]
    public class VampireIndicatorView : MonoBehaviour
    {
        private const float MinValue = 0;
        private const float MaxValue = 1;

        [SerializeField] private Image _fill;
        [SerializeField] private VampireZoneAnimator _vampireZoneAnimator;
        [SerializeField] private float _durationReloadInSeconds;
        [SerializeField] private float _durationUnloadInSeconds;

        private Button _button;
        private bool _isAnimating;

        public event Action VampirizmActivated;
        public event Action VampirizmDeactivated;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _fill.fillAmount = MinValue;
            _button.enabled = false;
            Reload();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void Unload()
        {
            if (_isAnimating) 
                return;

            _isAnimating = true;            

            _fill.DOFillAmount(MinValue, _durationUnloadInSeconds)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    _isAnimating = false;
                    _vampireZoneAnimator.Hide();
                    VampirizmDeactivated?.Invoke();
                    Reload();
                });
        }

        private void Reload()
        {
            if (_isAnimating)
                return;

            _isAnimating = true;

            _fill.DOFillAmount(MaxValue, _durationReloadInSeconds)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    _button.enabled = true;
                    _isAnimating = false;
                });
        }

        private void OnClick()
        {
            VampirizmActivated?.Invoke();
            _vampireZoneAnimator.Show();

            _button.enabled = false;
            Unload();
        }
    }
}