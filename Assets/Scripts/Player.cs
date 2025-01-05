using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private HotkeyReader _hotkeyReader;
    [SerializeField] private ItemDetector _itemDetector;
    [SerializeField] private Character _character;

    private void OnEnable()
    {
        _hotkeyReader.PressedMove += _character.Move;
        _hotkeyReader.PressedJump += _character.Jump;
        _itemDetector.CoinCollected += CoinCollect;
    }

    private void OnDisable()
    {
        _hotkeyReader.PressedMove -= _character.Move;
        _hotkeyReader.PressedJump -= _character.Jump;
        _itemDetector.CoinCollected -= CoinCollect;
    }

    private void CoinCollect(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}