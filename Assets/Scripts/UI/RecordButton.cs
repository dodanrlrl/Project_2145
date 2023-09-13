using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordButton : MonoBehaviour
{
    public Button recordButton; // �̹��� ��ư
    public TextMeshProUGUI recordText; // TextMeshPro �ؽ�Ʈ UI

    private bool isRecordVisible = false;
    private float lastClickTime;
    private float doubleClickTimeThreshold = 0.5f; // ���� Ŭ�� ���� (��: 0.5��)

    private void Start()
    {
        // �̹��� ��ư�� Ŭ�� �̺�Ʈ ����
        recordButton.onClick.AddListener(ToggleRecord);
    }

    public void ToggleRecord()
    {
        float currentTime = Time.time;
        if (currentTime - lastClickTime <= doubleClickTimeThreshold)
        {
            // ���� Ŭ�� ����: â �ݱ�
            HideRecord();
        }
        else
        {
            // �̱� Ŭ��: ���� ��� ���
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
        // ���� ����� ǥ���ϰ� ������ �����͸� �����ϴ� �ڵ� �ۼ�
        recordText.text = "1. 00m 00s 1000 \n" +
            "2. 01m 30s 800\n" +
            "3. 02m 15s 600";
        recordText.gameObject.SetActive(true);
    }

    private void HideRecord()
    {
        // ���� ����� ����� �ڵ� �ۼ�
        recordText.gameObject.SetActive(false);
    }
}

