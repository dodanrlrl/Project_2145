using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (ItemManager.Instance.isUseHU == true && this.gameObject.CompareTag("HealthUp"))
            return;

        if (ItemManager.Instance.isUsePU == true && this.gameObject.CompareTag("PowerUp"))
            return;

        if (ItemManager.Instance.isUseSU == true && this.gameObject.CompareTag("SpeedUp"))
            return;

        Debug.Log(collision.gameObject.name + "¡¢√À«—ªÛ¥Î");

        ItemManager.Instance.UseItem(this.gameObject);
    }
}
