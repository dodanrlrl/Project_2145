using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int damage;
    private int speed;

    Animation myAnim;
    Rigidbody2D myRigid;
    Collider2D myColl;

    private void Awake()
    {
        damage = 999;
        speed = 10;
        myAnim = GetComponent<Animation>();
        myRigid = GetComponent<Rigidbody2D>();
        myColl = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (transform.position.y >= 0f)
        {
            Debug.Log("Áß¾Ó µµ´Þ");
            Explosion();
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
    public void Explosion()
    {
        speed = 0;
        Destroy(gameObject,0.3f);
    }
}
