using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{    
    public event Action HitAttacked;

    /// <summary>
    /// ����������� ����� Animatiom Event, ����� ����� ������� ��� �����
    /// </summary>
    public void OnHit()
    {
        HitAttacked?.Invoke();
    }
}