using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{

    void Update()
    {
        Shoot();
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y) * Time.deltaTime;
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = ObjectPool.GetObject();//ÃÑ¾Ë»ý¼º
            bullet.transform.position = transform.position;
            bullet.DestroyBulletInvoke();
        }
    }

}
