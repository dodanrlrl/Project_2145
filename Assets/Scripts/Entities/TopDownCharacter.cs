using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacter : MonoBehaviour
{
    //public string Name { get; private set; }
    //public int CurrentHP { get; private set; }
    //public int MaxHP { get; private set; }
    //public float AttackDelay { get; private set; }
    //public float Speed { get; private set; }
    //public List<GameObject> Projectiles = new List<GameObject>();
    //public GameObject CurrentProjectile { get; private set; }

    public string Name;
    public int CurrentHP;
    public int MaxHP;
    public float AttackDelay;
    public float Speed;
    public List<GameObject> Projectiles = new List<GameObject>();
    public GameObject CurrentProjectile;
    public void SetCharacterInfo(string name, int maxHp, float attackDelay)
    {
        Name = name;
        MaxHP = maxHp;
        AttackDelay = attackDelay;
        CurrentHP = MaxHP;
    }
    public void ChangeCurrentProjectile()
    {
        if (Projectiles == null || Projectiles.Count == 0)
            return;

        int nextIndex = Projectiles.IndexOf(CurrentProjectile) + 1;
        if (nextIndex >= Projectiles.Count)
        {
            nextIndex = 0;
        }
        CurrentProjectile = Projectiles[nextIndex];
    }
}
