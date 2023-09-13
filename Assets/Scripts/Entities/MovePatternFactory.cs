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
    public static IEnumerator CircleMoveXDegree(TopDownCharacterController controller, float radius, float degree, MovePatternDirection centerPointDirection, MovePatternRotation rotateDirection)
    {
        TopDownCharacter character = controller.Character;
        Vector2 characterPosition = character.transform.position;
        float angle = 0f;
        Vector2 centerPoint = Vector2.zero;
        float diagonalAxisValue = Mathf.Cos(45 * Mathf.Deg2Rad);
        float initialAngle = 0;
        // 중심 원 위치에 따라 초기 각 설정.
        switch (centerPointDirection)
        {
            case MovePatternDirection.UpperLeft:
                centerPoint = new Vector2(characterPosition.x - diagonalAxisValue, characterPosition.y + diagonalAxisValue);
                initialAngle = -90 + 45;
                break;
            case MovePatternDirection.UpperRight:
                centerPoint = new Vector2(characterPosition.x + diagonalAxisValue, characterPosition.y + diagonalAxisValue);
                initialAngle = -90 - 45;
                break;
            case MovePatternDirection.LowerLeft:
                centerPoint = new Vector2(characterPosition.x - diagonalAxisValue, characterPosition.y - diagonalAxisValue);
                initialAngle = 90 - 45;
                break;
            case MovePatternDirection.LowerRight:
                centerPoint = new Vector2(characterPosition.x - diagonalAxisValue, characterPosition.y - diagonalAxisValue);
                initialAngle = 90 + 45;
                break;
            case MovePatternDirection.Up:
                centerPoint = new Vector2(characterPosition.x, characterPosition.y + radius);
                initialAngle = -90;
                break;
            case MovePatternDirection.Down:
                centerPoint = new Vector2(characterPosition.x, characterPosition.y - radius);
                initialAngle = 90;
                break;
            case MovePatternDirection.Left:
                centerPoint = new Vector2(characterPosition.x - radius, characterPosition.y);
                initialAngle = 90 - 90;
                break;
            case MovePatternDirection.Right:
                centerPoint = new Vector2(characterPosition.x + radius, characterPosition.y);
                initialAngle = 90 + 90;
                break;
        }
        int rotateCoefficient = 0;
        switch (rotateDirection)
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
            yield return null;
        }
    }

    public static IEnumerator RepeatMove(TopDownCharacterController controller, float moveDistance, float duration, MovePatternDirection moveDirection)
    {
        TopDownCharacter character = controller.Character;
        Vector2 startPosition = character.transform.position;
        Vector2 direction = Vector2.zero;

        switch (moveDirection)
        {
            case MovePatternDirection.UpperLeft:
                direction = new Vector2(-1, 1);
                break;
            case MovePatternDirection.UpperRight:
                direction = new Vector2(1, 1);
                break;
            case MovePatternDirection.LowerLeft:
                direction = new Vector2(-1, -1);
                break;
            case MovePatternDirection.LowerRight:
                direction = new Vector2(1, -1);
                break;
            case MovePatternDirection.Up:
                direction = new Vector2(0, 1);
                break;
            case MovePatternDirection.Down:
                direction = new Vector2(0, -1);
                break;
            case MovePatternDirection.Left:
                direction = new Vector2(-1, 0);
                break;
            case MovePatternDirection.Right:
                direction = new Vector2(1, 0);
                break;
        }
        direction = direction.normalized;

        while (duration > 0)
        {
            if (Vector2.Distance(startPosition, character.transform.position) > moveDistance)
                direction = direction * -1;
            controller.CallMoveEvent(direction);
            yield return null;
        }
    }
    public static IEnumerator MoveStraight(TopDownCharacterController controller, float moveDistance, MovePatternDirection moveDirection)
    {
        TopDownCharacter character = controller.Character;
        Vector2 startPosition = character.transform.position;
        Vector2 direction = Vector2.zero;

        switch (moveDirection)
        {
            case MovePatternDirection.UpperLeft:
                direction = new Vector2(-1, 1);
                break;
            case MovePatternDirection.UpperRight:
                direction = new Vector2(1, 1);
                break;
            case MovePatternDirection.LowerLeft:
                direction = new Vector2(-1, -1);
                break;
            case MovePatternDirection.LowerRight:
                direction = new Vector2(1, -1);
                break;
            case MovePatternDirection.Up:
                direction = new Vector2(0, 1);
                break;
            case MovePatternDirection.Down:
                direction = new Vector2(0, -1);
                break;
            case MovePatternDirection.Left:
                direction = new Vector2(-1, 0);
                break;
            case MovePatternDirection.Right:
                direction = new Vector2(1, 0);
                break;
        }
        direction = direction.normalized;
        while (Vector2.Distance(startPosition, character.transform.position) < moveDistance)
        {
            controller.CallMoveEvent(direction);
            yield return null;
        }
    }
}
