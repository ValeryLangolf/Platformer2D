using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private KeyCode _keyJump;
    [SerializeField] private KeyCode _keyAttack;

    public event Action<float> PressedMove;
    public event Action PressedJump;
    public event Action PressedAttack;

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        float factor = Input.GetAxisRaw(HorizontalAxis);
        PressedMove?.Invoke(factor);
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(_keyJump))
            PressedJump?.Invoke();
    }

    private void HandleAttackInput()
    {
        if (Input.GetKeyDown(_keyAttack))
            PressedAttack?.Invoke();
    }
}