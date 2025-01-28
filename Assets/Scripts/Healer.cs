using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private float _value;

    public void Apply(Health health)
    {
        health.Heal(_value);
        Destroy(gameObject);
    }
}