using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private TopDownCharacter _character;

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
        Arm arm = _character.GetCurrentArm();
        foreach (GameObject Spawner in arm.Spawners)
        {
            Bullet bullet = ObjectPool.Instance.GetObject();//������Ʈ Ǯ �ȿ��ִ� �Ѿ� ������
            bullet.transform.position = Spawner.transform.position;
            bullet.SetBulletInfo(arm.AttackPower, arm.ProjectileLaunchSpeed, arm.ProjectileType);
            bullet.SetSpriteAndScale();
            bullet.Move(transform.up);
        }
    }

}
