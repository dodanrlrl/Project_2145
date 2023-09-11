using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI Destroy;

    void Update()
    {
        CurrentScore.text = "";
        BestScore.text = "";
        Destroy.text = "";
    }
}
