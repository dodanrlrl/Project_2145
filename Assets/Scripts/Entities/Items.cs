using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float Duration = 5f;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(VanishItem());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (ItemManager.Instance.isUseHU == true && gameObject.CompareTag("HealthUp"))
            return;

        if (ItemManager.Instance.isUsePU == true && gameObject.CompareTag("PowerUp"))
            return;

        if (ItemManager.Instance.isUseSU == true && gameObject.CompareTag("SpeedUp"))
            return;

        Debug.Log(collision.gameObject.name + "Á¢ÃË");

        ItemManager.Instance.UseItem(gameObject);
    }

    public IEnumerator VanishItem()
    {
        while (Duration > 0f)
        {
            if (Duration < 3f)
            {
                Color color = _spriteRenderer.color;
                color = new Color(color.r, color.g, color.b, Duration / 3f);
                _spriteRenderer.color = color;
            }

            Duration -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
