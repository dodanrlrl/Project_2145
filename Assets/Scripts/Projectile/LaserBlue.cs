using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlue : ProjectileBase
{

    private void Start()
    {
        InitializeProjectile(3f, 5f);
    }
    void Update()
    {
        //transform.position += new Vector3(0, speed * Time.deltaTime,0);//총알 속도설정
        MoveProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)//적과 충돌 했을때
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DestroyProjectile();
            Debug.Log("충돌");
        }
    }
}
