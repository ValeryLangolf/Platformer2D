using System;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _distance;
    [SerializeField] private LayerMask targetLayer;

    public event Action Detected;
    public event Action Undetected;

    public Character Character { get; private set; }

    private void Update()
    {
        DetectObjectsInView();
    }

    private void DetectObjectsInView()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _distance, targetLayer);

        if (hit.collider != null && hit.collider.TryGetComponent<BodyCollider>(out BodyCollider body))
        {
            Character = body.Character;
            Detected?.Invoke();
        }
        else
        {
            Character = null;
            Undetected?.Invoke();
        }
    }
}