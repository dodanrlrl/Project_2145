using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    RectTransform rect;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        // ���� ��ǥ�� ��ġ�� ��ũ�� ��ǥ��� ��ȯ
        rect.position = Camera.main.WorldToScreenPoint(GameManager.I.player.transform.position);
    } 
}
