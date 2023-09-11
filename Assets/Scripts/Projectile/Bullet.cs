using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public void DestroyBulletInvoke()//������Ʈ Ǯ ������ ��ȯ�ϴ� �ð� ����
    {
        Invoke(nameof(DestroyBullet), 5f);
    }
    private void DestroyBullet()
    {
        ObjectPool.ReturnObj(this);
    }
   
    void Update()
    {
        //transform.position += new Vector3(0, speed * Time.deltaTime,0);//�Ѿ� �ӵ�����
        this.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)//���� �浹 ������
    {
        if(collision.gameObject.tag == "Enemy")
        {
            DestroyBullet();
        }
    }
}
