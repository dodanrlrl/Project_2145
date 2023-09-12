using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image item1;
    public Image item2;
    public Image item3;

    void Update()
    {
        if (GameManager.I.isHealthUp == true)
        {
            Color color = item1.color;
            color.a = 1f;
            item1.color = color;
        }
        else
        {
            Color color = item1.color;
            color.a = 0.2f;
            item1.color = color;
        }

        if (GameManager.I.isPowerUp == true)
        {
            Color color = item2.color;
            color.a = 1f;
            item2.color = color;
        }
        else
        {
            Color color = item2.color;
            color.a = 0.2f;
            item2.color = color;
        }

        if (GameManager.I.isSpeedUp == true)
        {
            Color color = item3.color;
            color.a = 1f;
            item3.color = color;
        }
        else
        {
            Color color = item3.color;
            color.a = 0.2f;
            item3.color = color;
        }
    }
}
