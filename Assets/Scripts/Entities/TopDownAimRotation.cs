using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    private SpriteRenderer _characterRenderer;
    private TopDownCharacterController _controller;
    

    private void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();
        _controller = GetComponent<TopDownCharacterController>();
        _controller.OnLookEvent += OnAim;
    }
    public void OnAim(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -rotZ);
    }

}
