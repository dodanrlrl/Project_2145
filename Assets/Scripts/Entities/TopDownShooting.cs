using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private TopDownCharacter _character;
    public GameObject Spawner;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _character = GetComponent<TopDownCharacter>();
    }
    private void Start()
    {
        _controller.OnShootEvent += Shoot;
    }
    public void Shoot()
    {
        //GameObject projectile = Instantiate(_character.CurrentProjectile);
        //projectile.transform.position = Spawner.transform.position;
        //projectile.transform.rotation = transform.rotation;
        //projectile.GetComponent<Rigidbody2D>().velocity = transform.up * 5;

        Bullet bullet = ObjectPool.GetObject();//오브젝트 풀 안에있는 총알 가져옴
        bullet.transform.position = Spawner.transform.position;
        bullet.transform.rotation = transform.rotation;

        if (bullet.gameObject.activeSelf)//충돌해서 이미 반환이 된게 아니라면
        {
            bullet.DestroyBulletInvoke();//가져온 총알을 다시 반환
        }
    }
}
