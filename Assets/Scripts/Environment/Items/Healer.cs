using UnityEngine;

public class Healer : Item
{
    [SerializeField] private float _value;

    public float Value => _value;
}