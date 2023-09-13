using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TopDownPlayerController : TopDownCharacterController
{
    private Camera _camera;

    protected override void Start()
    {
        base.Start();
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        CallMoveEvent(value.Get<Vector2>());
    }
    public void OnLook(InputValue value)
    {
        Vector2 worldPos = _camera.ScreenToWorldPoint(value.Get<Vector2>());
        Vector2 lookDirection = (worldPos - (Vector2)transform.position).normalized;
        if (lookDirection.magnitude > 0.9f)
            CallLookEvent(lookDirection);
    }
    public void OnShoot(InputValue value)
    {
        IsShooting = value.isPressed;

    }

    public void OnBomb()
    {        
        if (GameManager.Instance.playerBomb <= 0)
            return;
        else GameManager.Instance.CreateBomb();
    }
}
