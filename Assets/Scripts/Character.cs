using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private WallDetector _leftWallDetector;
    [SerializeField] private WallDetector _rightWallDetector;
    [SerializeField] private AnimatorWrapper _animatorWrapper;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;

    private bool _isLeftWall;
    private bool _isRightWall;

    private void OnEnable()
    {
        _groundDetector.Grounded += OnGrounded;
        _groundDetector.InAir += OnInAir;
        _leftWallDetector.InWall += OnLeftWallDetected;
        _leftWallDetector.OutWall += OnLeftWallUndetected;
        _rightWallDetector.InWall += OnRightWallDetected;
        _rightWallDetector.OutWall += OnRightWallUndetected;
    }

    private void OnDisable()
    {
        _groundDetector.Grounded -= OnGrounded;
        _groundDetector.InAir -= OnInAir;
        _leftWallDetector.InWall -= OnLeftWallDetected;
        _leftWallDetector.OutWall -= OnLeftWallUndetected;
        _rightWallDetector.InWall -= OnRightWallDetected;
        _rightWallDetector.OutWall -= OnRightWallUndetected;
    }

    public void Jump()
    {
        if (_groundDetector.IsGrounded)
        {
            _jumper.Jump();
            _animatorWrapper.EnableJump();
        }
    }

    public void Move(float factor)
    {
        if (factor < 0 && _isLeftWall == false)
        {
            _mover.Move(factor);
            _rotator.RotateLeft();
        }
        else if (factor > 0 && _isRightWall == false)
        {
            _mover.Move(factor);
            _rotator.RotateRight();
        }
        else
        {
            if (_groundDetector.IsGrounded)
                _animatorWrapper.EnableIdle();

            return;
        }

        _animatorWrapper.EnableWalking();
    }

    private void OnGrounded()
    {
        _animatorWrapper.EnableGround();
    }

    private void OnInAir()
    {
        _animatorWrapper.DisableGround();
    }

    private void OnLeftWallDetected()
    {
        _isLeftWall = true;
    }

    private void OnLeftWallUndetected()
    {
        _isLeftWall = false;
    }

    private void OnRightWallDetected()
    {
        _isRightWall = true;
    }

    private void OnRightWallUndetected()
    {
        _isRightWall = false;
    }
}