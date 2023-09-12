using UnityEngine;
using UnityEngine.UIElements;

public class TopDownMovement : MonoBehaviour
{
    protected TopDownCharacterController Controller;
    protected Rigidbody2D Rigidbody2D;
    protected SpriteRenderer SpriteRenderer;
    protected Animator Animator;
    protected TopDownCharacter Character;
    protected Vector2 MovementDirection = Vector2.zero;


    protected virtual void Start()
    {
        Controller = GetComponent<TopDownCharacterController>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
        Character = GetComponent<TopDownCharacter>();
        Controller.OnMoveEvent += Move;
    }
    protected virtual void FixedUpdate()
    {
        ApplyMovement(MovementDirection);
    }
    private void Move(Vector2 direction)
    {
        MovementDirection = direction;
    }
    private void ApplyMovement(Vector2 direction)
    {
        Rigidbody2D.velocity = Character.Speed * direction;
    }
}
