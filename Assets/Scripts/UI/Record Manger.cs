using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public Text recordText; // UI Text ������Ʈ ���� (���� ����� ǥ���� �ؽ�Ʈ)
    private List<Record> highScores = new List<Record>(); // ���� ����� ������ ����Ʈ

    private void Start()
    {
        LoadHighScores(); // ���� ���� �� ����� �ҷ���
        UpdateRecordText(); // �ؽ�Ʈ ������Ʈ
    }

    // ���� ����� PlayerPrefs���� �ҷ���
    private void LoadHighScores()
    {
        highScores.Clear(); // ����Ʈ �ʱ�ȭ

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

        // ������ ������������ ����
        highScores.Sort((a, b) => b.Score.CompareTo(a.Score));
    }

    // ���� ����� �ؽ�Ʈ�� ǥ��
    private void UpdateRecordText()
    {
        string textToShow = "���� ���\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            textToShow += (i + 1) + ". " + highScores[i].Time + " - " + highScores[i].Score + "\n";
        }

        recordText.text = textToShow;
    }
}

// �� ���ڵ带 ��Ÿ���� Ŭ����
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

