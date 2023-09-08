using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    TextMeshProUGUI myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            // F - 소수점 자릿수 설정 , D - 표시 자리수 고정
            // FloorToInt 소수점 버리기 

            case InfoType.Exp:
                myText.text = string.Format("EXP : {0:F2} %", GameManager.I.exp);                
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.I.level);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.I.kill);
                break;
            case InfoType.Time:
                int min = Mathf.FloorToInt(GameManager.I.gameTime / 60);
                int sec = Mathf.FloorToInt(GameManager.I.gameTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = GameManager.I.health;
                float maxHealth = GameManager.I.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
        }
    }
}
