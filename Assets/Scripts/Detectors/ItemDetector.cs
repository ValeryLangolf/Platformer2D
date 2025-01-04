using System;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public event Action<Coin> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Coin>(out Coin coin))
            CoinCollected?.Invoke(coin);            
    }
}