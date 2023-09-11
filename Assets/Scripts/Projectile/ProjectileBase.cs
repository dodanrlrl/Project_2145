using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileBase : MonoBehaviour
{
    protected float m_damage;
    protected float m_speed;
    public void DestroyProjectileInvoke()//오브젝트 풀 안으로 반환하는 시간 설정
    {
        Invoke(nameof(DestroyProjectile), 5f);
    }
    protected void DestroyProjectile()
    {
        ObjectPool.ReturnObj(this);
    }
    public virtual void InitializeProjectile(float damage, float speed)//발사체 정보 초기화
    {
        m_damage = damage;
        m_speed = speed;
    }

    protected void MoveProjectile()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }
}
