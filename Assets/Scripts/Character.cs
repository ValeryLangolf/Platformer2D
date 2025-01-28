using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GroundCollider _groundDetector;
    [SerializeField] private WallDetector _leftWallDetector;
    [SerializeField] private WallDetector _rightWallDetector;
    [SerializeField] private AnimatorWrapper _animatorWrapper;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private ZoneAttack _zoneAttack;

    private bool _isLeftWall;
    private bool _isRightWall;
    private float _damage;

    public event Action TouchedWall;
    public event Action UntouchedWall;

    private void OnEnable()
    {
        _groundDetector.Grounded += OnGrounded;
        _groundDetector.InAir += OnInAir;
        _leftWallDetector.InWall += OnLeftWallDetected;
        _leftWallDetector.OutWall += OnLeftWallUndetected;
        _rightWallDetector.InWall += OnRightWallDetected;
        _rightWallDetector.OutWall += OnRightWallUndetected;
        _attacker.HitAttacked += Hit;
    }

    private void OnDisable()
    {
        _groundDetector.Grounded -= OnGrounded;
        _groundDetector.InAir -= OnInAir;
        _leftWallDetector.InWall -= OnLeftWallDetected;
        _leftWallDetector.OutWall -= OnLeftWallUndetected;
        _rightWallDetector.InWall -= OnRightWallDetected;
        _rightWallDetector.OutWall -= OnRightWallUndetected;
        _attacker.HitAttacked -= Hit;
    }

    public void Jump(float force)
    {
        if (_groundDetector.IsGrounded)
        {
            _jumper.Jump(force);
            _animatorWrapper.EnableJump();
        }
    }

    public void Move(float factor, float speed)
    {
        if (factor < 0 && _isLeftWall == false)
        {
            _mover.Move(factor * speed);
            _rotator.RotateLeft();
        }
        else if (factor > 0 && _isRightWall == false)
        {
            _mover.Move(factor * speed);
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

    public void Attack(float damage)
    {
        _damage = damage;
        _animatorWrapper.EnableAttack();
    }

    public void Hit()
    {
        if (_zoneAttack.Character != null)
            _zoneAttack.Character.TakeDamage(_damage);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
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
        TouchedWall?.Invoke();
    }

    private void OnLeftWallUndetected()
    {
        _isLeftWall = false;
        UntouchedWall?.Invoke();
    }

    private void OnRightWallDetected()
    {
        _isRightWall = true;
        TouchedWall?.Invoke();
    }

    private void OnRightWallUndetected()
    {
        _isRightWall = false;
        UntouchedWall?.Invoke();
    }
}