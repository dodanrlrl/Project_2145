using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI Recordtext1;
    public TextMeshProUGUI Recordtext2;
    public TextMeshProUGUI Recordtext3;

    private int[] highScores = new int[3];
    private float[] highScoreTimes = new float[3];

    private bool isScoreVisible = false; // 점수를 보이게 할지 여부를 나타내는 변수

    void Start()
    {
        // 초기에 점수는 비활성화 상태로 시작
        SetScoreVisibility(false);

        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScoreTimes[i] = PlayerPrefs.GetFloat("HighScoreTime" + i, float.MaxValue);
            UpdateHighScoreText(i);
        }
    }

    public void ToggleScoreVisibility()
    {
        // 점수를 토글합니다. 보이면 숨기고, 숨겨져 있으면 보이게 합니다.
        isScoreVisible = !isScoreVisible;
        SetScoreVisibility(isScoreVisible);
    }

    private void SetScoreVisibility(bool isVisible)
    {
        Recordtext1.gameObject.SetActive(isVisible);
        Recordtext2.gameObject.SetActive(isVisible);
        Recordtext3.gameObject.SetActive(isVisible);
    }

    public void UpdateHighScores(int newScore, float newTime)
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            if (newScore > highScores[i] || (newScore == highScores[i] && newTime < highScoreTimes[i]))
            {
                int tempScore = highScores[i];
                float tempTime = highScoreTimes[i];

                highScores[i] = newScore;
                highScoreTimes[i] = newTime;

                newScore = tempScore;
                newTime = tempTime;

                PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
                PlayerPrefs.SetFloat("HighScoreTime" + i, highScoreTimes[i]);
                PlayerPrefs.Save();
                UpdateHighScoreText(i);
            }
        }
    }

    void UpdateHighScoreText(int index)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(highScoreTimes[index]);
        string timeText = string.Format("{0:D2}m {1:D2}s", timeSpan.Minutes, timeSpan.Seconds);
        string scoreText = "Score: " + highScores[index];
        string displayText = string.Format("{0}. {1} {2}", (index + 1), timeText, scoreText);

        switch (index)
        {
            case 0:
                Recordtext1.text = displayText;
                break;
            case 1:
                Recordtext2.text = displayText;
                break;
            case 2:
                Recordtext3.text = displayText;
                break;
        }
    }
}






