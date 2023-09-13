using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int damage;
    private int speed;

    Rigidbody2D myRigid;
    private void Awake()
    {
        damage = 999;
        speed = 10;
        myRigid = GetComponent<Rigidbody2D>();     
    }

    private void Update()
    {
        if (transform.position.y >= 0.1f)
        {
            GameManager.Instance.Explosion();
            Destroy(gameObject);
        }
    }
    public void Move(Vector2 Direction)
    {
        transform.up = Direction;
        myRigid.velocity = Direction * speed;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Boundary")
            return;
        else if (other.transform.tag == "Enemy")
        {
            other.gameObject.GetComponent<TopDownCharacter>().TakeDamage(damage);
        }
    }
    
}
