using UnityEngine;

public class Healer : Item
{
    [SerializeField] private float _value;

    public void Apply(Health health)
    {
        health.TakeHeal(_value);
        Destroy(gameObject);
    }
}