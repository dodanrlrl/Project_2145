using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private TopDownCharacter _character;
    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _character = GetComponent<TopDownCharacter>();
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }
    private void ApplyMovement(Vector2 direction)
    {
        _rigidbody2D.velocity = _character.Speed * direction;
    }
}
