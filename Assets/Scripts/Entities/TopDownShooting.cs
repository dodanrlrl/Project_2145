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
        Bullet bullet = ObjectPool.GetObject();//오브젝트 풀 안에있는 총알 가져옴
        bullet.transform.position = Spawner.transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetDirection(transform.up);
    }
}
