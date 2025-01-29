using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    }
}