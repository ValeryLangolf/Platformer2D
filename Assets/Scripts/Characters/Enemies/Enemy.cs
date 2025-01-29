using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float MinimumDistanceToTarget = 0.05f;
    private const int MultiplierLeft = -1;
    private const int MultiplierRight = 1;

    [SerializeField] private Character _character;
    [SerializeField] private Point _firstPoint;
    [SerializeField] private Point _secondPoint;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private ZoneAttack _zoneAttack;
    [SerializeField] private Health _health;

    [Header("Parameters:")]
    [SerializeField] private float _speedMoving;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _damage;

    private bool _isFirstTarget;
    private bool _isChasing;
    private bool _isOnAttacking;
    private Transform _currentTarget;

    private void Awake()
    {
        _currentTarget = _firstPoint.transform;
    }

    private void Update()
    {
        if (_isOnAttacking)
            return;

        Move();
    }

    private void OnEnable()
    {
        _playerDetector.Detected += OnChasing;
        _playerDetector.Undetected += OffChasing;
        _character.TouchedWall += OnJump;
        _zoneAttack.Detected += OnAttacking;
        _zoneAttack.Undetected += OffAttacking;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _playerDetector.Detected -= OnChasing;
        _playerDetector.Undetected -= OffChasing;
        _character.TouchedWall -= OnJump;
        _zoneAttack.Detected -= OnAttacking;
        _zoneAttack.Undetected -= OffAttacking;
        _health.Died -= OnDied;
    }

    private void OnChasing(Character player)
    {
        _isChasing = true;
        _currentTarget = player.transform;
    }

    private void OffChasing()
    {
        _isChasing = false;
        ReplaceTargetPoint();
    }

    private void OnJump()
    {
        _character.Jump(_forceJump);
    }

    private void OnAttacking()
    {
        _isOnAttacking = true;
        _character.Attack(_damage);
        _character.Move(0, 0);
    }

    private void OffAttacking()
    {
        _isOnAttacking = false;
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        bool isMinimumDistance = IsWithinMinimumDistance(_currentTarget.position, out float distance);

        if (_isChasing == false && isMinimumDistance)
            ReplaceTargetPoint();

        float currentMultiplier = 0;

        if (distance < -MinimumDistanceToTarget)
            currentMultiplier = MultiplierLeft;
        else if (distance > MinimumDistanceToTarget)
            currentMultiplier = MultiplierRight;

        _character.Move(currentMultiplier, _speedMoving);
    }

    private void ReplaceTargetPoint()
    {
        _isFirstTarget = !_isFirstTarget;
        _currentTarget = _isFirstTarget ? _firstPoint.transform : _secondPoint.transform;
    }

    private bool IsWithinMinimumDistance(Vector3 target, out float distance)
    {
        distance = target.x - _character.transform.position.x;

        return Mathf.Abs(distance) < MinimumDistanceToTarget;
    }
}