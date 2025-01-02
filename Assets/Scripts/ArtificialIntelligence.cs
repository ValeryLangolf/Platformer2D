using UnityEngine;

public class ArtificialIntelligence : MonoBehaviour
{
    private const float MinimumDistanceToTarget = 0.05f;
    private const int FactorLeft = -1;
    private const int FactorRight = 1;

    [SerializeField] private Character _enemy;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private float _currentTargetPositionX;
    private int _factor;
    private bool _isFirstTarget;

    private void Awake()
    {
        ClarifyTarget();
    }

    private void Update()
    {                
        _enemy.Move(_factor);

        float distance = Mathf.Abs(_currentTargetPositionX - transform.position.x);

        if (distance < MinimumDistanceToTarget)
        {
            _isFirstTarget = !_isFirstTarget;         
            ClarifyTarget();
        }
    }

    private void ClarifyTarget()
    {
        _currentTargetPositionX = _isFirstTarget ? _firstPoint.position.x : _secondPoint.position.x;
        _factor = _isFirstTarget ? FactorLeft : FactorRight;
    }
}