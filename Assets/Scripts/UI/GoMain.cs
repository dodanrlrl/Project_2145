using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMain : MonoBehaviour
{
    public void Main()
    {
        GameManager.Instance.EndGame();
        SceneManager.LoadScene("StartScene");
    }
}
