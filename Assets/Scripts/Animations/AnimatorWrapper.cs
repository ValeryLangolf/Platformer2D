using UnityEngine;

public class AnimatorWrapper : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsGrounded = nameof(IsGrounded);
    private const string Jump = nameof(Jump);
    private const string Attack = nameof(Attack);

    [SerializeField] private Animator _animator;

    public void EnableWalking()
    {
        _animator.SetBool(AnimatorData.Params.IsWalking, true);
    }

    public void DisableWalking()
    {
        _animator.SetBool(AnimatorData.Params.IsWalking, false);
    }

    public void EnableJump()
    {
        _animator.SetTrigger(AnimatorData.Params.Jump);
    }

    public void EnableAttack()
    {
        _animator.SetTrigger(AnimatorData.Params.Attack);
    }

    public void EnableGround()
    {
        _animator.SetBool(AnimatorData.Params.IsGrounded, true);
    }

    public void DisableGround()
    {
        _animator.SetBool(AnimatorData.Params.IsGrounded, false);
    }
}