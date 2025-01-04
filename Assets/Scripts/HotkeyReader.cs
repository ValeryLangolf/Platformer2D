using System;
using UnityEngine;

public class HotkeyReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private KeyCode KeyJump = KeyCode.Space;

    public event Action<float> PressedMove;
    public event Action PressedJump;

    private void Update()
    {
        ListenWalkInput();
        ListenJumpInput();
    }

    private void ListenWalkInput()
    {
        float factor = Input.GetAxisRaw(HorizontalAxis);        
        PressedMove?.Invoke(factor);
    }

    private void ListenJumpInput()
    {
        if (Input.GetKeyDown(KeyJump))
            PressedJump?.Invoke();
    }
}