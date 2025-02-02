using UnityEngine;

namespace VampireIndicator
{
    [RequireComponent(typeof(Animator))]
    public class VampireZoneAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Show()
        {
            _animator.SetTrigger(AnimatorData.Params.Enter);
        }

        public void Hide()
        {
            _animator.SetTrigger(AnimatorData.Params.Exit);
        }
    }
}