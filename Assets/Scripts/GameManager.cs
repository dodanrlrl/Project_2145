using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameObject player;

    [Header("# Game Control")]
    public float gameTime;

    [Header("# Player Info")]
    public float exp;
    public int level;
    public int kill; 
    public int health;
    public int maxHealth = 100;

    void Awake()
    {
        I = this;
    }


    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        // Test Code
        kill++;
        health--;
        GetExp();
    }
    public void GetExp()
    {
        exp++;
        if (exp == 100f)
        {
            level++;
            exp = 0;
        }
    }
}
