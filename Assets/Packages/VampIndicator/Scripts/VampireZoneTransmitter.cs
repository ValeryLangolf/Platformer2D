using System.Collections;
using UnityEngine;

namespace VampireIndicator
{
    public class VampireZoneTransmitter : MonoBehaviour
    {
        [SerializeField] private VampireZoneDetector _detector;
        [SerializeField] private VampireIndicatorView _indicator;
        [SerializeField] private Character _owner;
        [SerializeField] private float _value;
        [SerializeField] private float _rateUpdate;

        private Coroutine _coroutine;
        private WaitForSeconds _wait;
        private CircleCollider2D _collider;
        private bool _isSteal = true;

        private void Awake()
        {
            _wait = new(_rateUpdate);
            _collider = _detector.gameObject.GetComponent<CircleCollider2D>();
            OffTriggerCollider();
        }

        private void OnEnable()
        {
            _indicator.VampirizmActivated += OnTriggerCollider;
            _indicator.VampirizmDeactivated += OffTriggerCollider;
            _detector.Detected += OnStartSteal;
            _detector.Undetected += OnStopSteal;
        }

        private void OnDisable()
        {
            _indicator.VampirizmActivated -= OnTriggerCollider;
            _indicator.VampirizmDeactivated -= OffTriggerCollider;
            _detector.Detected -= OnStartSteal;
            _detector.Undetected -= OnStopSteal;
        }

        private void OnTriggerCollider() => _collider.enabled = true;

        private void OffTriggerCollider() => _collider.enabled = false;

        private void OnStartSteal(ItemDetector enemy)
        {
            if (_coroutine != null)
                return;

            _coroutine = StartCoroutine(StealHealthOverTime(enemy.Character));
        }

        private void OnStopSteal()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }        

        private IEnumerator StealHealthOverTime(Character character)
        {
            while (_isSteal)
            {
                yield return _wait;

                if (character == null)
                {
                    OnStopSteal();
                    yield break;
                }

                StealHealth(character);
            }
        }

        private void StealHealth(Character character)
        {
            character.TakeDamage(_value);
            _owner.TakeHeal(_value);
        }
    }
}