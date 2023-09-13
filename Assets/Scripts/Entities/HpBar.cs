using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private Transform _hp;
    private const string HP = "Hp";

    private void Start()
    {
        _hp = transform.Find(HP);
    }

    public void SetHp(float percentage)
    {
        Mathf.Clamp(percentage, 0, 1);
        _hp.localScale = new Vector2(percentage, 1);
    }
}
