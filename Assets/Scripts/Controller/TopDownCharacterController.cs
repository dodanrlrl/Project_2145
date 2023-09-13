using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnShootEvent;
    public TopDownCharacter Character { get; private set; }

    protected bool IsShooting;
    private float _timeSinceLastAttack;
    
    protected virtual void Start()
    {
        Character = GetComponent<TopDownCharacter>();
    }

    protected virtual void Update()
    {
        Arm arm = Character.GetCurrentArm();
        if (_timeSinceLastAttack < arm.AttackDelay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsShooting && _timeSinceLastAttack >= arm.AttackDelay)
        {
            CallShootEvent();
            _timeSinceLastAttack = 0;
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallShootEvent()
    {
        OnShootEvent?.Invoke();
    }
}
