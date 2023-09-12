using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{
    public TopDownCharacter _character;
    public static ObjectPool Instance;
    private GameObject poolingObj;
    private Queue<ProjectileBase> poolingObjQueue = new Queue<ProjectileBase>();

    private void Awake()
    {
        Instance = this;
        Init(3);
    }

    private ProjectileBase CreateObj()//지정된 총알 생성
    {
        poolingObj = _character.CurrentProjectile;
        ProjectileBase temp = Instantiate(poolingObj, transform).GetComponent<ProjectileBase>();
        temp.gameObject.SetActive(false);
        return temp;
    }

    public void Init(int count)//오브젝트 풀에 총알 장전
    {
        for(int i = 0; i < count; i++) 
        {
            poolingObjQueue.Enqueue(CreateObj());
        }
    }

    public void InitializePoolObject()//총알이 변경되었을때 오브젝트풀안과 발사된 총알 초기화
    {
        GameObject[] projectiles;

        poolingObjQueue.Clear();

        projectiles = GameObject.FindGameObjectsWithTag("Projectile");//이미 발사된 총알 삭제

        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }

        GameObject forDestroy = Instance.gameObject;//오브젝트 풀 안에 있는 총알 삭제
        foreach (Transform child in forDestroy.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public static ProjectileBase GetObject()//총알을 발사할때 오브젝트 풀안에서 꺼내오고 부족하면 새로 생성
    {
        if(Instance.poolingObjQueue.Count > 0)
        {
           ProjectileBase obj = Instance.poolingObjQueue.Dequeue();
           obj.transform.SetParent(null);
           obj.gameObject.SetActive(true);

           return obj;
        }
        else
        {
            ProjectileBase newObj = Instance.CreateObj();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    public static void ReturnObj(ProjectileBase projectile)//발사된 총알을 다시 오브젝트 풀안으로 반환
    {
        projectile.gameObject.SetActive(false);
        projectile.transform.position = Vector2.zero;
        projectile.transform.SetParent(Instance.transform);

        Instance.poolingObjQueue.Enqueue(projectile);

    }

}
