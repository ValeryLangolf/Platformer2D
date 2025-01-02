using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action Grounded;
    public event Action InAir;
    public event Action CoinCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
            Grounded?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
            InAir?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
            Grounded?.Invoke();

        if (collision.transform.TryGetComponent<Coin>(out _))
        {
            CoinCollected?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Ground>(out _))
            InAir?.Invoke();
    }
}