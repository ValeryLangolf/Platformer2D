using UnityEngine;

public class AnimatorWrapper : MonoBehaviour
{
    private const string WalkingName = "IsWalking";
    private const string JumpTriggerName = "Jump";
    private const string AttackTriggerName = "Attack";
    private const string GroundedName = "IsGrounded";

    [SerializeField] private Animator _animator;

    public void EnableIdle()
    {
        _animator.SetBool(WalkingName, false);
    }

    public void EnableWalking()
    {
        _animator.SetBool(WalkingName, true);
    }

    public void EnableJump()
    {
        _animator.SetTrigger(JumpTriggerName);
    }

    public void EnableAttack()
    {
        _animator.SetTrigger(AttackTriggerName);
    }

    public void EnableGround()
    {
        _animator.SetBool(GroundedName, true);
    }

    public void DisableGround()
    {
        _animator.SetBool(GroundedName, false);
    }
}