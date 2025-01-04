using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public event Action Grounded;
    public event Action InAir;

    public bool IsGrounded => _numberOccurrences != 0;

    private int _numberOccurrences;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
        {
            _numberOccurrences++;
            Grounded?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
        {
            if (--_numberOccurrences == 0)
                InAir?.Invoke();
        }
    }
}