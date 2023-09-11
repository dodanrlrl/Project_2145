using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileBase : MonoBehaviour
{
    protected float m_damage;
    protected float m_speed;
    public void DestroyProjectileInvoke()//������Ʈ Ǯ ������ ��ȯ�ϴ� �ð� ����
    {
        Invoke(nameof(DestroyProjectile), 5f);
    }
    protected void DestroyProjectile()
    {
        ObjectPool.ReturnObj(this);
    }
    public virtual void InitializeProjectile(float damage, float speed)//�߻�ü ���� �ʱ�ȭ
    {
        m_damage = damage;
        m_speed = speed;
    }

    protected void MoveProjectile()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }
}
