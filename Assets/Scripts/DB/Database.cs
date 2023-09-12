using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Database : MonoBehaviour
{
    private static Database _i;
    public static Database Instance
    {
        get
        {
            if (_i == null)
               _i = FindAnyObjectByType<Database>();
            return _i;
        }
    }
    private Dictionary<ProjectileType, Sprite> _bulletSprites = new Dictionary<ProjectileType, Sprite>();


    private void Awake()
    {
        if (_i == null)
            _i = this;
        else if (_i != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public Sprite GetBulletSpriteByProjectileType(ProjectileType type)
    {
        Sprite sprite = null;
        switch (type)
        {
            case ProjectileType.LaserGunBullet:
                sprite = Resources.Load<Sprite>("Images/Lasers/M484BulletCollection1-removevg-preview");
                break;
            case ProjectileType.PowerUpLaserGunBullet:
                sprite = Resources.Load<Sprite>("Images/Lasers/M484BulletCollection1-removevg-preview");
                break;
            case ProjectileType.GunBullet:
                sprite = Resources.Load<Sprite>("Images/Lasers/M484BulletCollection1-removevg-preview");
                break;
            case ProjectileType.PowerUpGunBullet:
                sprite = Resources.Load<Sprite>("Images/Lasers/M484BulletCollection1-removevg-preview");
                break;
            case ProjectileType.CannonBullet:
                sprite = Resources.Load<Sprite>("Images/Lasers/M484BulletCollection1-removevg-preview");
                break;
            case ProjectileType.PowerUpCannonBullet:
                sprite = Resources.Load<Sprite>("Images/Lasers/M484BulletCollection1-removevg-preview");
                break;
            default:
                break;
        }
        return sprite;
    }
    public Vector2 GetBulletLocalScaleByProjectileType(ProjectileType type)
    {
        Vector2 localScale = Vector2.zero;
        switch (type)
        {
            case ProjectileType.LaserGunBullet:
                localScale = new Vector2(1.4f, 1.4f);
                break;
            case ProjectileType.PowerUpLaserGunBullet:
                localScale = new Vector2(1.6f, 1.6f);
                break;
            case ProjectileType.GunBullet:
                localScale = new Vector2(1.5f, 1.5f);
                break;
            case ProjectileType.PowerUpGunBullet:
                localScale = new Vector2(1.6f, 1.6f);
                break;
            case ProjectileType.CannonBullet:
                localScale = new Vector2(2.5f, 2.5f);
                break;
            case ProjectileType.PowerUpCannonBullet:
                localScale = new Vector2(2.8f, 2.8f);
                break;
            default:
                break;
        }
        return localScale;
    }
}
