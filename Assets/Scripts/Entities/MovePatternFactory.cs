using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.TextCore.Text;

public class MovePatternFactory : MonoBehaviour
{
    public static IEnumerator MoveInCircleXDegree(TopDownCharacterController controller, float radius, float degree, MovePatternStartPosition patternStartPosition, MovePatternRotation patternRotation)
    {
        TopDownCharacter character = controller.Character;
        Vector2 characterPosition = character.transform.position;
        float angle = 0f;
        Vector2 centerPoint = Vector2.zero;
        float diagonalAxisValue = Mathf.Cos(45 * Mathf.Deg2Rad);
        float initialAngle = 0;
        // 중심 원 위치에 따라 초기 각 설정.
        switch (patternStartPosition)
        {
            case MovePatternStartPosition.UpperLeft:
                centerPoint = new Vector2(characterPosition.x - diagonalAxisValue, characterPosition.y + diagonalAxisValue);
                initialAngle = -90 + 45;
                break;
            case MovePatternStartPosition.UpperRight:
                centerPoint = new Vector2(characterPosition.x + diagonalAxisValue, characterPosition.y + diagonalAxisValue);
                initialAngle = -90 - 45;
                break;
            case MovePatternStartPosition.LowerLeft:
                centerPoint = new Vector2(characterPosition.x - diagonalAxisValue, characterPosition.y - diagonalAxisValue);
                initialAngle = 90 - 45;
                break;
            case MovePatternStartPosition.LowerRight:
                centerPoint = new Vector2(characterPosition.x - diagonalAxisValue, characterPosition.y - diagonalAxisValue);
                initialAngle = 90 + 45;
                break;
            case MovePatternStartPosition.Up:
                centerPoint = new Vector2(characterPosition.x, characterPosition.y + radius);
                initialAngle = -90;
                break;
            case MovePatternStartPosition.Down:
                centerPoint = new Vector2(characterPosition.x, characterPosition.y - radius);
                initialAngle = 90;
                break;
            case MovePatternStartPosition.Left:
                centerPoint = new Vector2(characterPosition.x - radius, characterPosition.y);
                initialAngle = 90 - 90;
                break;
            case MovePatternStartPosition.Right:
                centerPoint = new Vector2(characterPosition.x + radius, characterPosition.y);
                initialAngle = 90 + 90;
                break;
        }
        int rotateCoefficient = 0;
        switch (patternRotation)
        {
            case MovePatternRotation.Clockwise:
                rotateCoefficient = -1;
                break;
            case MovePatternRotation.CounterClockwise:
                rotateCoefficient = 1;
                break;
        }
        Vector2 direction = Vector2.down;


        while (angle < degree)
        {
            characterPosition = character.transform.position;
            angle += 360 * ((character.Speed * Time.deltaTime) / (2f * (float)Math.PI * radius));

            // 경로 계산 (실제 원은 아니고 프레임이 낮을수록 오차가 커짐)
            float x = centerPoint.x + Mathf.Cos((angle * rotateCoefficient + initialAngle) * Mathf.Deg2Rad) * radius;
            float y = centerPoint.y + Mathf.Sin((angle * rotateCoefficient + initialAngle) * Mathf.Deg2Rad) * radius;

            Vector2 targetPosition = new Vector2(x, y);
            direction = targetPosition - characterPosition;
            direction = direction.normalized;

            controller.CallMoveEvent(direction);
            Debug.Log(angle);
            yield return null;
        }

        // 패턴이 끝났다면 마지막 방향으로 계속 이동.
        while (true)
        {
            controller.CallMoveEvent(direction);
            yield return null;
        }
    }
}
