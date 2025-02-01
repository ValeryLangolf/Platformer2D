using System;
using System.Collections;
using UnityEngine;

namespace MyIndicatorHealth
{
    public class Autohealer : MonoBehaviour
    {
        private WaitForSeconds _timeRate;
        private WaitForSeconds _timeDelay;
        private Coroutine _coroutine;
        private float _valueHealing;

        public event Action<float> Healed;

        public void SetDelay(float delayStartInSeconds)
        {
            _timeDelay = new WaitForSeconds(delayStartInSeconds);
        }

        public void SetRate(float timeInSeconds)
        {
            _timeRate = new WaitForSeconds(timeInSeconds);
        }

        public void SetHealingValue(float healingValue)
        {
            _valueHealing = healingValue;
        }

        public void StartHealing()
        {
            StopHealing();
            _coroutine = StartCoroutine(HealOverTime());
        }

        public void StopHealing()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator HealOverTime()
        {
            yield return _timeDelay;

            while (_coroutine != null)
            {
                yield return _timeRate;

                Healed?.Invoke(_valueHealing);
            }
        }
    }
}