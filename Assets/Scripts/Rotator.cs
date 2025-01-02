using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField, Range(0, 360)] private float _angleLeft;
    [SerializeField, Range(0, 360)] private float _angleRight;

    private Coroutine _coroutine;
    private bool _isLeft;

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
        _coroutine = StartCoroutine(Rotating(targetRotation));
    }

    private IEnumerator Rotating(Quaternion targetRotation)
    {
        while (transform.rotation != targetRotation)
        {
            yield return null;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speed * Time.deltaTime);
        }
    }
}