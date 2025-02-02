using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Model _model;
    [SerializeField] private float _speed;
    [SerializeField, Range(0, 360)] private float _angleLeft;
    [SerializeField, Range(0, 360)] private float _angleRight;

    private Coroutine _coroutine;
    private bool _isLeft;
    private Transform _transform;

    private void Awake()
    {
        _transform = _model.transform;
    }

    public void RotateLeft()
    {
        if (_isLeft)
            return;

        _isLeft = true;
        StartRotation(_angleLeft);
    }

    public void RotateRight()
    {
        if (_isLeft == false) 
            return;

        _isLeft = false;
        StartRotation(_angleRight);
    }

    private void StartRotation(float angle)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        _coroutine = StartCoroutine(RotateTo(targetRotation));
    }

    private IEnumerator RotateTo(Quaternion targetRotation)
    {
        while (_transform.rotation != targetRotation)
        {
            yield return null;

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, _speed * Time.deltaTime);
        }
    }
}