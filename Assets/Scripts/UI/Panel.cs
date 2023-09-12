using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public enum UItype { Life, Bomb, item }
    public UItype type;

    public Image[] myLifes;
    public Image[] myBombs;
    public Image[] myItems;

    private void Awake()
    {
        switch (type)
        {
            case UItype.Life:
                myLifes = GetComponentsInChildren<Image>(true);
                break;
            case UItype.Bomb:
                myBombs = GetComponentsInChildren<Image>(true);
                break;
            case UItype.item:
                myItems = GetComponentsInChildren<Image>(true);
                break;
        }
    }

    private void LateUpdate()
    {
        int lifes = GameManager.Instance.playerLife;
        int bombs = GameManager.Instance.playerBomb;
        int items = GameManager.Instance.playerItem;

        switch (type)
        {
            case UItype.Life:               
                for (int i = 0; i< myLifes.Length; i++)
                {
                    myLifes[i].gameObject.SetActive(i < lifes);
                }
                break;
            case UItype.Bomb:
                for (int i = 0; i < myBombs.Length; i++)
                {
                    myBombs[i].gameObject.SetActive(i < bombs);
                }
                break;
            case UItype.item:
                for (int i = 0; i < myItems.Length; i++)
                {
                    myItems[i].gameObject.SetActive(i < items);
                }
                break;
        }
               
    }
}
