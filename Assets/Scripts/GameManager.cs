using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _i;
    public static GameManager Instance
    {
        get
        {
            if (_i == null)
            {
                _i = FindObjectOfType<GameManager>();
                if (_i == null)
                    Debug.Log("게임 매니저가 없습니다.");
            }
            return _i;
        }
    }
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
        if (_i == null)
            _i = this;
        else if (_i != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        playerHealth = playerMaxHealth;
        gameTime = 0;
        Time.timeScale = 1;
        IsPlaying = true;
    }

    void Update()
    {     
        // Test Code
        playerKill++;
        playerHealth--;
        GetExp();
        GameLogic();

    }
    void GameLogic()
    {        
        if (IsPlaying)
        {
            gameTime += Time.deltaTime;
            if (playerHealth == 0)
            {
                playerLife--;
                if (playerLife <= 0)
                {
                    IsPlaying = false;
                    Time.timeScale = 0;
                    // GameEnd() 결과창 띄우기
                }
                playerHealth = playerMaxHealth;
            }
        }
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
