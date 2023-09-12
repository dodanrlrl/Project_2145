using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public string mainSceneName = "MainScene";

    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}

