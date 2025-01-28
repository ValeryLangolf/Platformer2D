using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{    
    public event Action HitAttacked;

    /// <summary>
    /// «апускаетс€ через Animatiom Event, когда кулак выт€нут дл€ удара
    /// </summary>
    public void OnHit()
    {
        HitAttacked?.Invoke();
    }
}