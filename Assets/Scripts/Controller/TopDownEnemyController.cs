using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TopDownEnemyController : TopDownCharacterController
{
    private List<IEnumerator> _movePatterns = new List<IEnumerator>();
    protected const string PLAYER_UI_BAR = "PlayerUIBar";

    // 현재 테스트용
    protected override void Start()
    {
        base.Start();

        StartCoroutine(OnMove());
        StartCoroutine(OnLook());
        StartCoroutine(OnShoot());
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        // 임시로 파괴하게 만들었고 차후에 오브젝트 풀에 반납해야함. 
    }
    protected virtual IEnumerator OnMove()
    {
        //패턴이 없으면 기본 패턴 추가
        if (_movePatterns.Count == 0)
        {
            AddMovePattern(DefaultMovePattern());
        }

        foreach (IEnumerator pattern in _movePatterns)
        {
            yield return StartCoroutine(pattern);
        }
        // 패턴을 다 끝마쳤으면 기본 패턴으로 움직여서 멈추는 것을 방지.
        StartCoroutine(DefaultMovePattern());

    }
    protected virtual IEnumerator OnLook()
    {
        // 객체별로 패턴 짜주기
        Vector2 playerPosition = Vector2.zero;
        Vector2 direction = Vector2.zero;
        while (true)
        {
            // 게임 매니저에게서 플레이어 받아서 해당위치 바라봄 
            playerPosition = GameManager.Instance.player.transform.position;
            direction = playerPosition - (Vector2)gameObject.transform.position;
            CallLookEvent(direction);
            yield return null;
        }
    }
    protected virtual IEnumerator OnShoot()
    {
        // 차후에 혹시 샷을 멈춰야 하는 기획이 생기면 작성
        Camera _camera = Camera.main;
        float camHeightSize = _camera.orthographicSize * 2;
        float meterPerPixel = camHeightSize / Screen.height;
        float halfWidthSize = meterPerPixel * Screen.width / 2;
        float halfHeightSize = _camera.orthographicSize;
        Vector2 sizeDelta = GameManager.Instance.PlayerUI.transform.Find(PLAYER_UI_BAR).GetComponent<RectTransform>().sizeDelta;
        float playerUIHeight = sizeDelta.y * meterPerPixel;

        while (true)
        {
            if (transform.position.x < -halfWidthSize || transform.position.x > halfWidthSize)
                IsShooting = false;
            else if (transform.position.y < -halfHeightSize + playerUIHeight || transform.position.y > halfHeightSize)
                IsShooting = false;
            else
                IsShooting = true;
            yield return null;
        }
    }
    public void AddMovePattern(IEnumerator movePattern)
    {
        _movePatterns.Add(movePattern);
    }
    protected IEnumerator DefaultMovePattern()
    {
        while(true)
        {
            CallMoveEvent(Vector2.down);
            yield return null;
        }
    }

}
