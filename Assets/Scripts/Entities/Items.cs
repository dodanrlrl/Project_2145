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
                case "HealthUp": // 10�ʰ� �ִ�ü�� 50 ����
                    break;
                case "PowerUp": // 10�ʰ� ���ݷ� ����
                    break;
                case "SpeedUp": // 10�ʰ� �̵��ӵ� ����
                    break;
            }
        }
    }
}
