using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int Damage;
    private Rigidbody2D Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void DestroyBullet()
    {
        ObjectPool.Instance.ReturnObj(this);
    }
    public void SetDirection(Vector2 Direction)
    {
        transform.up = Direction;
        Rigidbody.velocity = Direction * Speed;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            ; //Todo
        else if (collision.transform.tag == "Enemy")
            ; //TOdo
        else if (collision.transform.tag == "Boundary")
            DestroyBullet();
    }
}
