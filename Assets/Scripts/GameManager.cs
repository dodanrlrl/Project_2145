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
                    Debug.Log("���� �Ŵ����� �����ϴ�.");
            }
            return _i;
        }
    }
    public GameObject player;
    public GameObject bomb;
    public GameObject bombEffect;

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
    public int playerShield = 0;
    public int playerMaxShield = 200;
    public int playerBomb = 3;
    public int playerItem = 5;


    

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
    public void CreateBomb()
    {
        playerBomb--;
        GameObject _bomb = Instantiate(bomb);
        Bomb newBomb = _bomb.GetComponent<Bomb>();
        newBomb.Move(transform.up);        
    }
    public void Explosion()
    {
        // 화면 중앙 애니메이션
        bombEffect.SetActive(true);
    }
}
