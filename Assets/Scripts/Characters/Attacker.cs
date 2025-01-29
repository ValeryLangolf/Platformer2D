using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{    
    public event Action HitAttacked;

    public void OnHit()
    {
        HitAttacked?.Invoke();
    }
}