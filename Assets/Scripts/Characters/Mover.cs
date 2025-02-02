using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Transform _transform;

    private void Awake()
    {
        _transform = _character.transform;
    }

    public void Move(float value)
    {
        Vector3 position = _transform.position;
        position.x += value * Time.deltaTime;
        _transform.position = position;
    }
}