using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public Text recordText; // UI Text 컴포넌트 연결 (상위 기록을 표시할 텍스트)
    private List<Record> highScores = new List<Record>(); // 상위 기록을 저장할 리스트

    private void Start()
    {
        LoadHighScores(); // 게임 시작 시 기록을 불러옴
        UpdateRecordText(); // 텍스트 업데이트
    }

    // 상위 기록을 PlayerPrefs에서 불러옴
    private void LoadHighScores()
    {
        highScores.Clear(); // 리스트 초기화

        for (int i = 1; i <= 10; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            if (score > 0)
            {
                string time = PlayerPrefs.GetString("HighScoreTime" + i, "00:00:00");
                Record record = new Record(time, score);
                highScores.Add(record);
            }
        }

        // 점수를 내림차순으로 정렬
        highScores.Sort((a, b) => b.Score.CompareTo(a.Score));
    }

    // 상위 기록을 텍스트로 표시
    private void UpdateRecordText()
    {
        string textToShow = "상위 기록\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            textToShow += (i + 1) + ". " + highScores[i].Time + " - " + highScores[i].Score + "\n";
        }

        recordText.text = textToShow;
    }
}

// 각 레코드를 나타내는 클래스
public class Record
{
    public string Time { get; set; }
    public int Score { get; set; }

    public Record(string time, int score)
    {
        Time = time;
        Score = score;
    }
}

