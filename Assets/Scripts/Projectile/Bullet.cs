using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public void DestroyBulletInvoke()
    {
        Invoke(nameof(DestroyBullet), 5f);
    }
    private void DestroyBullet()
    {
        ObjectPool.ReturnObj(this);
    }
   
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime,0);
    }
}
