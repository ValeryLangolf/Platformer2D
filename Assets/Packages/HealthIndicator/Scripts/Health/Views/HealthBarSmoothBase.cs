using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MyIndicatorHealth
{
    public abstract class HealthBarSmoothBase : HealthView
    {
        [SerializeField] protected float _valueDelta;
        [SerializeField] protected float _delayInSeconds;

        protected readonly WaitForFixedUpdate _wait = new();
        protected WaitForSeconds _waitDelay;
        protected Coroutine _coroutine;
        protected bool _isDelay = true;

        public event Action Died;

        protected virtual void Awake()
        {
            _waitDelay = new(_delayInSeconds);
        }

        public override void UpdateHealth(float currentValue, float maxValue)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _isDelay = false;
            }

            float target = currentValue / maxValue;
            _coroutine = StartCoroutine(ChangeTo(GetTargetImage(target), target));
        }

        protected abstract Image GetTargetImage(float target);

        protected IEnumerator ChangeTo(Image imageSmooth, float target)
        {
            if (_isDelay)
                yield return _waitDelay;

            while (Mathf.Abs(imageSmooth.fillAmount - target) > 0.001f)
            {
                yield return _wait;
                imageSmooth.fillAmount = Mathf.MoveTowards(imageSmooth.fillAmount, target, _valueDelta);
            }

            if (imageSmooth.fillAmount == 0)
                Died?.Invoke();

                _coroutine = null;
            _isDelay = true;
        }
    }
}