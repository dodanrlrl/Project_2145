using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;

public class TopDownEnemyController : TopDownCharacterController
{
    private void Start()
    {
        StartCoroutine(OnMove());
        StartCoroutine(OnLook());
        StartCoroutine(OnShoot());
    }
    protected virtual IEnumerator OnMove()
    {
        // 객체별로 패턴 짜주기
        while (true)
        {
            Vector2 moveDirection = new Vector2(0, -1);
            CallMoveEvent(moveDirection);
            yield return null;
        }
    }
    protected virtual IEnumerator OnLook()
    {
        // 객체별로 패턴 짜주기
        while (true)
        {
            // 게임 매니저에게서 플레이어 받아서 해당위치 바라봄 
            CallLookEvent(new Vector2(0, -1));
            yield return null;
        }
    }
    protected virtual IEnumerator OnShoot()
    {
        // 객체별로 패턴 짜주기
        while (true)
        {
            IsShooting = true;
            yield return null;
        }
    }
}
