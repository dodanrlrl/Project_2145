using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnShootEvent;
    protected TopDownCharacter Character;

    protected bool IsShooting;
    private float _timeSinceLastAttack;
    
    protected virtual void Awake()
    {
        Character = GetComponent<TopDownCharacter>();
    }

    protected virtual void Update()
    {
        if (_timeSinceLastAttack < Character.AttackDelay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsShooting && _timeSinceLastAttack >= Character.AttackDelay)
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
