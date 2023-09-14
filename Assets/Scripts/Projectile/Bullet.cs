using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public string LaunchCharacterTag;
    public float Speed;
    public int Damage;
    private ProjectileType _projectileType;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer SpriteRenderer;

    public void SetBulletInfo(string launchCharacterTag, float attackPower, float projectileSpeed, ProjectileType projectileType)
    {
        LaunchCharacterTag = launchCharacterTag;
        _projectileType = projectileType;
        Speed = projectileSpeed;

        switch (projectileType)
        {
            case ProjectileType.LaserGunBullet:
                Damage = (int)(Mathf.Round(0.8f * attackPower));
                break;
            case ProjectileType.PowerUpLaserGunBullet:
                Damage = (int)(Mathf.Round(1f * attackPower));
                break;
            case ProjectileType.GunBullet:
                Damage = (int)(Mathf.Round(1f * attackPower));
                break;
            case ProjectileType.PowerUpGunBullet:
                Damage = (int)(Mathf.Round(1.2f * attackPower));
                break;
            case ProjectileType.CannonBullet:
                Damage = (int)(Mathf.Round(1.3f * attackPower));
                break;
            case ProjectileType.PowerUpCannonBullet:
                Damage = (int)(Mathf.Round(1.6f * attackPower));
                break;
        }

    }
    public void SetSpriteAndScale()
    {
        if (SpriteRenderer == null)
        {
            Debug.Log("SpriteRenderer가 없습니다.");
            return;
        }
        SpriteRenderer.sprite = Database.Instance.GetBulletSpriteByProjectileType(_projectileType);
        transform.localScale = Database.Instance.GetBulletLocalScaleByProjectileType(_projectileType);
        PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;

    }
    private void DestroyBullet()
    {
        ObjectPool.Instance.ReturnObj(this);
        Destroy(GetComponent<Collider2D>());
    }
    public void Move(Vector2 Direction)
    {
        if (Rigidbody == null)
        {
            Debug.Log("Rigidbody가 없습니다.");
            return;
        }

        transform.up = Direction;
        Rigidbody.velocity = Direction * Speed;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        // 발사한 캐릭터의 콜라이더면 무시
        if (LaunchCharacterTag == other.tag)
            return;

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<TopDownCharacter>().TakeDamage(Damage);
            DestroyBullet();
        }
        else if (other.tag == "Enemy" || other.tag == "Boss")
        {
            other.gameObject.GetComponent<TopDownCharacter>().TakeDamage(Damage);
            DestroyBullet();
        }
        else if (other.tag == "Boundary")
        {
            DestroyBullet();
        }
    }
}
