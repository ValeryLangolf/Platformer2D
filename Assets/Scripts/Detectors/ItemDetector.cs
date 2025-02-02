using System;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    [SerializeField] private Character _character;

    public event Action<Item> ItemCollected;

    public Character Character => _character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Item>(out Item item))
            ItemCollected?.Invoke(item);
    }
}