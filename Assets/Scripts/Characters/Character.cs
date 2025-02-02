using System;
using UnityEngine;
using MyIndicatorHealth;

public class Character : MonoBehaviour
{
    [Header("Phisics")]
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Rotator _rotator;

    [Header("Detectors")]
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private WallDetector _leftWallDetector;
    [SerializeField] private WallDetector _rightWallDetector;
    [SerializeField] private ItemDetector _bodyCollider;
    [SerializeField] private ZoneAttack _zoneAttack;

    [Header("Other")]
    [SerializeField] private Health _health;
    [SerializeField] private HealthBarSmoothBase _healthBar;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private AnimatorWrapper _animatorWrapper;

    private bool _isLeftWall;
    private bool _isRightWall;
    private float _damage;

    public event Action TouchedWall;
    public event Action UntouchedWall;
    public event Action Died;
    public event Action<Item> ItemCollected;
    public event Action InZoneAttack;
    public event Action OutZoneAttack;

    private void OnEnable()
    {
        _groundDetector.Grounded += OnGrounded;
        _groundDetector.InAir += OnInAir;
        _leftWallDetector.InWall += OnLeftWallDetected;
        _leftWallDetector.OutWall += OnLeftWallUndetected;
        _rightWallDetector.InWall += OnRightWallDetected;
        _rightWallDetector.OutWall += OnRightWallUndetected;
        _attacker.HitAttacked += Hit;
        _bodyCollider.ItemCollected += CollectItem;
        _healthBar.Died += OnDied;
        _zoneAttack.Detected += SendOnAttacking;
        _zoneAttack.Undetected += SendOffAttacking;
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
        _bodyCollider.ItemCollected -= CollectItem;
        _healthBar.Died -= OnDied;
        _zoneAttack.Detected -= SendOnAttacking;
        _zoneAttack.Undetected -= SendOffAttacking;
    }

    public void SetIgnoreLayer(int layer) => _bodyCollider.gameObject.layer = layer;

    public void SetTargetLayer(LayerMask layer) => _zoneAttack.SetTargetLayer(layer);

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
                _animatorWrapper.DisableWalking();

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

    public void TakeDamage(float damage) => _health.TakeDamage(damage);

    public void TakeHeal(float heal) => _health.TakeHeal(heal);

    private void OnGrounded() => _animatorWrapper.EnableGround();

    private void OnInAir() => _animatorWrapper.DisableGround();

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

    private void CollectItem(Item item) => ItemCollected?.Invoke(item);

    private void OnDied() => Died?.Invoke();

    private void SendOnAttacking() => InZoneAttack?.Invoke();
    
    private void SendOffAttacking() => OutZoneAttack?.Invoke();
}