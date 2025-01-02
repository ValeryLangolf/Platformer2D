using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorWrapper : MonoBehaviour
{
    private const string WalkingName = "IsRunning";
    private const string JumpName = "Jump";
    private const string GroundedName = "IsGrounded";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.SetTrigger(JumpName);
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