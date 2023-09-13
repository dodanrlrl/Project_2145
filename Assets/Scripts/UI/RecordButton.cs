using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordButton : MonoBehaviour
{
    public Button recordButton; // 이미지 버튼
    public TextMeshProUGUI recordText; // TextMeshPro 텍스트 UI

    private bool isRecordVisible = false;
    private float lastClickTime;
    private float doubleClickTimeThreshold = 0.5f; // 더블 클릭 간격 (예: 0.5초)

    private void Start()
    {
        // 이미지 버튼에 클릭 이벤트 연결
        recordButton.onClick.AddListener(ToggleRecord);
    }

    public void ToggleRecord()
    {
        float currentTime = Time.time;
        if (currentTime - lastClickTime <= doubleClickTimeThreshold)
        {
            // 더블 클릭 감지: 창 닫기
            HideRecord();
        }
        else
        {
            // 싱글 클릭: 상위 기록 토글
            isRecordVisible = !isRecordVisible;
            if (isRecordVisible)
            {
                ShowRecord();
            }
            else
            {
                HideRecord();
            }
        }
        lastClickTime = currentTime;
    }

    private void ShowRecord()
    {
        // 상위 기록을 표시하고 적절한 데이터를 설정하는 코드 작성
        recordText.text = "1. 00m 00s 1000 \n" +
            "2. 01m 30s 800\n" +
            "3. 02m 15s 600";
        recordText.gameObject.SetActive(true);
    }

    private void HideRecord()
    {
        // 상위 기록을 숨기는 코드 작성
        recordText.gameObject.SetActive(false);
    }
}

