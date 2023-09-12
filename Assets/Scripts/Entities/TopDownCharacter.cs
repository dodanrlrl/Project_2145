using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacter : MonoBehaviour
{
    public int CurrentHP = 100;
    public int MaxHP = 100;
    public float Speed = 5;
    [SerializeField]
    private List<Arm> _arms = new List<Arm>();
    private int _currentArmIndex;
    public bool isPowerUp;

    private void Start()
    {
        _arms.AddRange(GetComponentsInChildren<Arm>());
    }
    public void SetCharacterInfo(int maxHp, float speed)
    {
        MaxHP = maxHp;
        CurrentHP = MaxHP;
        Speed = speed;
    }
    public void ChangeArm()
    {
        if (_arms.Count <= 0)
        {
            Debug.Log("무장이 없습니다.");
            return;
        }
        _currentArmIndex++;
        if (_currentArmIndex >= _arms.Count)
            _currentArmIndex = 0;
    }
    public Arm GetCurrentArm()
    {
        if (_arms.Count <= 0)
        {
            Debug.Log("무장이 없습니다.");
            return null;
        }
        return _arms[_currentArmIndex];
    }
    public void PowerUp()
    {
        if (isPowerUp)
            return;
        isPowerUp = true;
        foreach (Arm arm in _arms)
            arm.ProjectileType++;
    }
    public void PowerUpEnd()
    {
        if (!isPowerUp)
            return;
        isPowerUp = false;
        foreach (Arm arm in _arms)
            arm.ProjectileType--;
    }
}
