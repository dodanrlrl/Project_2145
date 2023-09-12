using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class TopDownEnemyController : TopDownCharacterController
{
    private List<Func<IEnumerator>> _movePatterns = new List<Func<IEnumerator>>();
    private Vector2 moveDirection = Vector2.zero;

    // 현재 테스트용
    private new void Start()
    {
        base.Start();
    }
    private void OnEnable()
    {
        AddMovePattern(TestMovePattern);
        OnMove();
        StartCoroutine(OnLook());
        StartCoroutine(OnShoot());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        // 임시로 파괴하게 만들었고 차후에 오브젝트 풀에 반납해야함. 
    }
    protected virtual void OnMove()
    {
        //// 객체별로 패턴 짜주기
        //if (_movePatterns.Count == 0)
        //{
        //    while (true)
        //    {
        //        moveDirection = new Vector2(0, -1);
        //        CallMoveEvent(moveDirection);
        //        yield return null;
        //    }
        //}

        StartCoroutine(_movePatterns[0]());
    }
    protected virtual IEnumerator OnLook()
    {
        // 객체별로 패턴 짜주기
        while (true)
        {
            // 게임 매니저에게서 플레이어 받아서 해당위치 바라봄 
            CallLookEvent(GameManager.Instance.player.transform.position);
            yield return null;
        }
    }
    protected virtual IEnumerator OnShoot()
    {
        // 차후에 혹시 샷을 멈춰야 하는 기획이 생기면 작성
        while (true)
        {
            IsShooting = true;
            yield return null;
        }
    }
    public void AddMovePattern(Func<IEnumerator> movePattern)
    {
        _movePatterns.Add(movePattern);
    }

    // 현재 테스트용
    public IEnumerator TestMovePattern()
    {
        while(true)
        {
            CallMoveEvent(Vector2.down);
            yield return null;
        }
    }
}
