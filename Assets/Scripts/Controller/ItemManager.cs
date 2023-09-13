using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Image HealthUp;
    public Image PowerUp;
    public Image SpeedUp;

    public bool isUseHU = false;
    public bool isUsePU = false;
    public bool isUseSU = false;

    void Awake()
    {
        Instance = this;
    }

    public void UseItem(GameObject item)
    {
        Destroy(item);
        StartCoroutine(Buff(item.tag));
    }

    IEnumerator Buff(string tag)
    {
        Color color;

        switch (tag)
        {
            case "HealthUp":
                Debug.Log("버프시작");
                isUseHU = true;
                color = HealthUp.color;
                color.a = 1f;
                HealthUp.color = color;
                GameManager.Instance.player.GetComponent<TopDownCharacter>().MaxHP += 50;
                GameManager.Instance.player.GetComponent<TopDownCharacter>().CurrentHP += 50;
                yield return new WaitForSecondsRealtime(10);
                GameManager.Instance.player.GetComponent<TopDownCharacter>().MaxHP -= 50;
                if (GameManager.Instance.player.GetComponent<TopDownCharacter>().CurrentHP > GameManager.Instance.player.GetComponent<TopDownCharacter>().MaxHP)
                    GameManager.Instance.player.GetComponent<TopDownCharacter>().CurrentHP = GameManager.Instance.player.GetComponent<TopDownCharacter>().MaxHP;
                Debug.Log("버프해제");
                isUseHU = false;
                color.a = 0.2f;
                HealthUp.color = color;
                break;
            case "PowerUp":
                Debug.Log("버프시작");
                isUsePU = true;
                GameManager.Instance.player.GetComponent<TopDownCharacter>().PowerUp();
                color = PowerUp.color;
                color.a = 1f;
                PowerUp.color = color;
                yield return new WaitForSecondsRealtime(10);
                Debug.Log("버프해제");
                isUsePU = false;
                GameManager.Instance.player.GetComponent<TopDownCharacter>().PowerUpEnd();
                color.a = 0.2f;
                PowerUp.color = color;
                break;
            case "SpeedUp":
                Debug.Log("버프시작");
                isUseSU = true;
                GameManager.Instance.player.GetComponent<TopDownCharacter>().Speed += 5;
                color = SpeedUp.color;
                color.a = 1f;
                SpeedUp.color = color;
                yield return new WaitForSecondsRealtime(10);
                Debug.Log("버프해제");
                isUseSU = false;
                GameManager.Instance.player.GetComponent<TopDownCharacter>().Speed -= 5;
                color.a = 0.2f;
                SpeedUp.color = color;
                break;
            default:
                break;
        }
    }
}
