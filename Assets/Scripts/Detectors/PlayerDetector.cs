using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public event Action<Character> Detected;
    public event Action Undetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<ItemDetector>(out ItemDetector body))
            Detected?.Invoke(body.Character);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<ItemDetector>(out _))
            Undetected?.Invoke();
    }
}