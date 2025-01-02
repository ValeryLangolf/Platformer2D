using UnityEngine;

public class HotkeyReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private Character _characterPlayer;
    [SerializeField] private KeyCode KeyJump = KeyCode.Space;

    private void Update()
    {
        ListenWalkInput();
        ListenJumpInput();
    }

    private void ListenWalkInput()
    {
        float factor = Input.GetAxisRaw(HorizontalAxis);
        _characterPlayer.Move(factor);
    }

    private void ListenJumpInput()
    {
        if (Input.GetKeyDown(KeyJump))
            _characterPlayer.Jump();
    }
}