using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    Animator animator;
    public void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void OnEnable()
    {
        Off(animator.runtimeAnimatorController.animationClips.ToList().First().length);

    }
    public IEnumerator Off(float animtime)
    {
        yield return new WaitForSeconds(animtime);
        gameObject.SetActive(false);
    }
}
