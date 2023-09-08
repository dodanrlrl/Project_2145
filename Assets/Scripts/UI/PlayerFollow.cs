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
        // 월드 좌표계 위치를 스크린 좌표계로 변환
        rect.position = Camera.main.WorldToScreenPoint(GameManager.I.player.transform.position);
    } 
}
