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
        //transform.position += new Vector3(0, speed * Time.deltaTime,0);//�Ѿ� �ӵ�����
        MoveProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)//���� �浹 ������
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DestroyProjectile();
            Debug.Log("�浹");
        }
    }
}
