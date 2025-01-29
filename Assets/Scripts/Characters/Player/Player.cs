using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private BodyCollider _bodyCollider;
    [SerializeField] private Character _character;
    [SerializeField] private Health _health;

    [Header("Parameters:")]
    [SerializeField] private float _speedMoving;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _damage;

    private void OnEnable()
    {
        _inputService.PressedMove += Move;
        _inputService.PressedJump += Jump;
        _inputService.PressedAttack += Attack;
        _bodyCollider.ItemCollected += CollectItem;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _inputService.PressedMove -= Move;
        _inputService.PressedJump -= Jump;
        _inputService.PressedAttack -= Attack;
        _bodyCollider.ItemCollected -= CollectItem;
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

    private void CollectItem(Item item)
    {
        if (item is Coin coin)
            Destroy(coin.gameObject);
        else if (item is Healer healer)
            healer.Apply(_health);
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }
}