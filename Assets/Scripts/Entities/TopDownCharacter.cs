using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacter : MonoBehaviour
{
    public int CurrentHP;
    public int MaxHP = 100;
    public float AttackDelay = 0.2f;
    public float Speed = 5f;
    public List<GameObject> Projectiles = new List<GameObject>();
    public GameObject CurrentProjectile;

    public void SetCharacterInfo(int maxHp, float attackDelay, float speed)
    {
        MaxHP = maxHp;
        AttackDelay = attackDelay;
        Speed = speed;
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

        ObjectPool.Instance.InitializePoolObject();//�Ѿ� �ʱ�ȭ
        ObjectPool.Instance.MakeObjects(20);//�ʱ�ȭ �� �Ѿ� ������Ʈ Ǯ�� ����
    }
}
