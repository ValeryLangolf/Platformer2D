using System;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    [SerializeField] private Character _character;

    public event Action<Coin> CoinCollected;
    public event Action<Healer> HealerCollected;

    public Character Character => _character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Coin>(out Coin coin))
            CoinCollected?.Invoke(coin);
        else if (collision.transform.TryGetComponent<Healer>(out Healer healer))
            HealerCollected?.Invoke(healer);
    }
}