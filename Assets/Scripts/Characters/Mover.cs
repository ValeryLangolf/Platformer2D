using UnityEngine;

public class Mover : MonoBehaviour
{
    public void Move(float value)
    {
        Vector3 position = transform.position;
        position.x += value * Time.deltaTime;
        transform.position = position;
    }
}