using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            switch (transform.tag)
            {
                case "HealthUp": // 10초간 최대체력 50 증가
                    break;
                case "PowerUp": // 10초간 공격력 증가
                    break;
                case "SpeedUp": // 10초간 이동속도 증가
                    break;
            }
        }
    }
}
