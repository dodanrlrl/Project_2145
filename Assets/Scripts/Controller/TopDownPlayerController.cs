using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TopDownPlayerController : TopDownCharacterController
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        CallMoveEvent(value.Get<Vector2>());
    }
    public void OnLook(InputValue value)
    {
        
        Vector2 worldPos = _camera.ScreenToWorldPoint(value.Get<Vector2>().normalized);
        Vector2 lookDirection = (worldPos - (Vector2)transform.position).normalized;
        CallLookEvent(lookDirection);
    }
    public void OnShoot(InputValue value)
    {
        IsShooting = value.isPressed;
    }
}
