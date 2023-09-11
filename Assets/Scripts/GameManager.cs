using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameObject player;
    public bool IsPlaying = false;


    [Header("# Game Control")]
    public float gameTime;

    [Header("# Player Info")]
    public float playerExp;
    public int playerLevel;
    public int playerKill; 
    public int playerHealth;
    public int playerMaxHealth = 100;
    public int playerLife = 3;

    

    void Awake()
    {
        I = this;
    }


    void Start()
    {
        playerHealth = playerMaxHealth;
        gameTime = 0;
        Time.timeScale = 1;
        IsPlaying = true;
        GameLogic();
    }

    void Update()
    {
        // Test Code
        playerKill++;
        playerHealth--;
        GetExp();
        
    }
    void GameLogic()
    {        
        //while (IsPlaying)
        //{
        //    gameTime += Time.deltaTime;
        //    if (playerHealth == 0)
        //    {
        //        playerLife--;
        //        if (playerLife <= 0)
        //        {
        //            IsPlaying = false;
        //            Time.timeScale = 0;
        //            break;
        //            // GameEnd() 결과창 띄우기
        //        }
        //        playerHealth = playerMaxHealth;
        //    }
        //}
    }
    public void GetExp()
    {
        playerExp++;
        if (playerExp == 100f)
        {
            playerLevel++;
            playerExp = 0;
        }
    }
}
