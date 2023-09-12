using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public int AttackPower = 10;
    public float AttackDelay = 0.2f;
    public float ProjectileLaunchSpeed = 5;
    public ProjectileType ProjectileType;
    public List<GameObject> Spawners;
    public void SetArmInfo(int attackPower, float attackDelay, float projectileLaunchSpeed, ProjectileType projectileType)
    {
        AttackPower = attackPower;
        AttackDelay = attackDelay;
        ProjectileLaunchSpeed = projectileLaunchSpeed;
        ProjectileType = projectileType;
    }
}