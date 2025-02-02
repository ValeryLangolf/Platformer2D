using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private Character _character;

    [Header("Layers:")]
    [SerializeField] private string _ignore;
    [SerializeField] private LayerMask _target;
    
    [Header("Parameters:")]
    [SerializeField] private float _speedMoving;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _damage;

    private void Awake()
    {
        _character.SetIgnoreLayer(LayerMask.NameToLayer(_ignore));
        _character.SetTargetLayer(_target);
    }

    private void OnEnable()
    {
        _inputService.PressedMove += Move;
        _inputService.PressedJump += Jump;
        _inputService.PressedAttack += Attack;
        _character.ItemCollected += CollectItem;
        _character.Died += OnDied;
    }

    private void OnDisable()
    {
        _inputService.PressedMove -= Move;
        _inputService.PressedJump -= Jump;
        _inputService.PressedAttack -= Attack;
        _character.ItemCollected -= CollectItem;
        _character.Died -= OnDied;
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
        {
            _character.TakeHeal(healer.Value);
            Destroy(healer.gameObject);
        }
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }
}