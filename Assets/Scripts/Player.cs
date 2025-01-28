using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HotkeyReader _hotkeyReader;
    [SerializeField] private BodyCollider _bodyCollider;
    [SerializeField] private Character _character;
    [SerializeField] private Health _health;

    [Header ("Parameters:")]
    [SerializeField] private float _speedMoving;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _damage;

    private void OnEnable()
    {
        _hotkeyReader.PressedMove += Move;
        _hotkeyReader.PressedJump += Jump;
        _hotkeyReader.PressedAttack += Attack;
        _bodyCollider.CoinCollected += CoinCollect;
        _bodyCollider.HealerCollected += Heal;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _hotkeyReader.PressedMove -= Move;
        _hotkeyReader.PressedJump -= Jump;
        _hotkeyReader.PressedAttack -= Attack;
        _bodyCollider.CoinCollected -= CoinCollect;
        _bodyCollider.HealerCollected -= Heal;
        _health.Died -= OnDied;
    }

    private void Move(float directionMultiplier)
    {
        _character.Move(directionMultiplier, _speedMoving);
    }

    private void Jump()
    {
        _character.Jump(_forceJump);
    }

    private void Attack()
    {
        _character.Attack(_damage);
    }

    private void CoinCollect(Coin coin)
    {
        Destroy(coin.gameObject);
    }
    
    private void Heal(Healer healer)
    {
        healer.Apply(_health);
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }
}