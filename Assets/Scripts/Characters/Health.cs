using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MaxHP = 100;

    [SerializeField] private float _value;

    public event Action<float> ValueChanged;
    public event Action Died;

    public void TakeDamage(float value)
    {
        if (value < 0)
            throw new ArgumentException(ErrorMessages.NegativeValue);

        _value -= value;

        ValueChanged?.Invoke(_value);

        if (_value <= 0)
            Died?.Invoke();
    }

    public void TakeHeal(float value)
    {
        if (value < 0)
            throw new ArgumentException(ErrorMessages.NegativeValue);

        _value += value;

        if (_value > MaxHP)
            _value = MaxHP;

        ValueChanged?.Invoke(_value);
    }
}