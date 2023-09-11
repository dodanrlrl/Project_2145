using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public void DestroyBulletInvoke()//오브젝트 풀 안으로 반환하는 시간 설정
    {
        Invoke(nameof(DestroyBullet), 5f);
    }
    private void DestroyBullet()
    {
        ObjectPool.ReturnObj(this);
    }
   
    void Update()
    {
        //transform.position += new Vector3(0, speed * Time.deltaTime,0);//총알 속도설정
        this.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)//적과 충돌 했을때
    {
        if(collision.gameObject.tag == "Enemy")
        {
            DestroyBullet();
        }
    }
}
