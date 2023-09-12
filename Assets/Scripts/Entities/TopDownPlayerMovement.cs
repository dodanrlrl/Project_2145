using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class TopDownPlayerMovement : TopDownMovement
{
    private float _positionClampValueX;
    private float _positionClampValueY;
    private float _playerUIHeight;
    private const string PLAYER_UI_BAR = "PlayerUIBar";
    protected override void Start()
    {
        base.Start();
        Init();
    }
    private void Update()
    {
        ClampPlayerPosition();
    }
    private void Init()
    {
        Camera _camera = Camera.main;
        float camHeightSize = _camera.orthographicSize * 2;
        float meterPerPixel = camHeightSize / Screen.height;
        float halfWidthSize = meterPerPixel * Screen.width / 2;
        float halfHeightSize = _camera.orthographicSize;

        Bounds bounds = SpriteRenderer.sprite.bounds;
        float maxExtentValue = Mathf.Max(bounds.extents.x * 2, bounds.extents.y * 2);

        _positionClampValueX = halfWidthSize - maxExtentValue;
        _positionClampValueY = halfHeightSize - maxExtentValue;
        Vector2 sizeDelta = GameManager.Instance.PlayerUI.transform.Find(PLAYER_UI_BAR).GetComponent<RectTransform>().sizeDelta;
        _playerUIHeight = sizeDelta.y * meterPerPixel;
    }
    private void ClampPlayerPosition()
    {
        Vector3 position = Character.transform.position;
        if (position.x > _positionClampValueX || position.x < -_positionClampValueX)
        {
            position.x = Mathf.Clamp(position.x, -_positionClampValueX, _positionClampValueX);
        }
        if (position.y > _positionClampValueY ||  position.y < -_positionClampValueY + _playerUIHeight)
        {
            position.y = Mathf.Clamp(position.y, -_positionClampValueY + _playerUIHeight, _positionClampValueY);
        }
             
        Character.transform.position = position;
    }
}
