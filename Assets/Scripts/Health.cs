using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MaxHP = 100;

    [SerializeField] private float _health;

    public event Action<float> Changed;
    public event Action Died;

    public void TakeDamage(float value)
    {
        if (value < 0)
            throw new ArgumentException(ErrorMessages.NegativeValue);

        _health -= value;

        Changed?.Invoke(_health);

        if (_health <= 0)
            Died?.Invoke();
    }

    public void Heal(float value)
    {
        if (value < 0)
            throw new ArgumentException(ErrorMessages.NegativeValue);

        _health += value;

        if (_health > MaxHP)
            _health = MaxHP;

        Changed?.Invoke(_health);
    }
}