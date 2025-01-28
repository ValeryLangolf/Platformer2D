using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Character _target;
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private float _smoothSpeed;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        if (_target == null) 
            return;

        Vector3 desiredPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);

        float halfHeight = _camera.orthographicSize;
        float halfWidth = halfHeight * _camera.aspect;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, _minPosition.position.x + halfWidth, _maxPosition.position.x - halfWidth);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, _minPosition.position.y + halfHeight, _maxPosition.position.y - halfHeight);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
    }
}