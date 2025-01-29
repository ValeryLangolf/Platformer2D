using System;
using System.Collections;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    private const float TimeWait = 0.2f;

    [SerializeField, Min(0.1f)] private float _distance;
    [SerializeField] private LayerMask _targetLayer;

    public event Action Detected;
    public event Action Undetected;

    private RaycastHit2D[] _hits = new RaycastHit2D[10];
    private WaitForSeconds _waiting = new(TimeWait);
    private bool _isWorking = true;

    public Character Character { get; private set; }

    private void Awake()
    {
        StartCoroutine(Timing());
    }

    private void DetectObjectsInView()
    {
        int hitCount = Physics2D.RaycastNonAlloc(transform.position, transform.up, _hits, _distance, _targetLayer);

        bool detected = false;

        for (int i = 0; i < hitCount; i++)
        {
            if (_hits[i].collider != null && _hits[i].collider.TryGetComponent<BodyCollider>(out BodyCollider body))
            {
                Character = body.Character;
                Detected?.Invoke();
                detected = true;
                break; 
            }
        }

        if (!detected)
        {
            Character = null;
            Undetected?.Invoke();
        }
    }

    private IEnumerator Timing()
    {
        while (_isWorking)
        {
            yield return _waiting;

            DetectObjectsInView();
        }        
    }
}