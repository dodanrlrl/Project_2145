using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health, Shield }
    public InfoType type;

    TextMeshProUGUI myText;
    Slider mySlider;
    private TopDownCharacter _playerCharacter;

    private void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        mySlider = GetComponent<Slider>();
        _playerCharacter = GameManager.Instance.player.GetComponent<TopDownCharacter>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            // F - �Ҽ��� �ڸ��� ���� , D - ǥ�� �ڸ��� ����
            // FloorToInt �Ҽ��� ������ 

            case InfoType.Exp:
                myText.text = string.Format("EXP : {0:F2} %", GameManager.Instance.playerExp);                
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.Instance.playerLevel);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.Instance.playerKill);
                break;
            case InfoType.Time:
                int min = Mathf.FloorToInt(GameManager.Instance.gameTime / 60);
                int sec = Mathf.FloorToInt(GameManager.Instance.gameTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                _playerCharacter.SetHpBar();
                break;
            case InfoType.Shield:
                float curShield = GameManager.Instance.playerShield;
                float maxShield = GameManager.Instance.playerMaxShield;
                mySlider.value = curShield / maxShield;
                break;

        }
    }
}
