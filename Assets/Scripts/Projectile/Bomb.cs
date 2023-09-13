using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int damage;
    private int speed;
    private bool arrivedExplosionPoint;

    Rigidbody2D myRigid;
    private void Awake()
    {
        damage = 50;
        speed = 10;
        arrivedExplosionPoint = false;
        myRigid = GetComponent<Rigidbody2D>();     
    }
    public void Move(Vector2 Direction)
    {
        myRigid.velocity = Direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BombExplosionPoint")
        {
            GameManager.Instance.Explosion();
            Destroy(gameObject);
        }
    }
}
