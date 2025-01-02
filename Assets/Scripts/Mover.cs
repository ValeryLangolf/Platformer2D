using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(float factor)
    {
        if (factor == 0)
            return;

        Vector3 position = transform.position;
        position.x += factor * _speed * Time.deltaTime;
        transform.position = position;
    }
}