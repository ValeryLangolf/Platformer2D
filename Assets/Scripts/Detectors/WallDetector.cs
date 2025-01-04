using System;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public event Action InWall;
    public event Action OutWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
            InWall?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
            OutWall?.Invoke();
    }
}