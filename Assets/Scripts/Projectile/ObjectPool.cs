using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject poolingObj;
    private Queue<Bullet> poolingObjQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;
        Init(10);
    }

    private Bullet CreateObj()
    { 
        Bullet temp = Instantiate(poolingObj, transform).GetComponent<Bullet>();
        temp.gameObject.SetActive(false);
        return temp;
    }

    private void Init(int count)
    {
        for(int i = 0; i < count; i++) 
        {
            poolingObjQueue.Enqueue(CreateObj());
        }
    }

    public static Bullet GetObject()
    {
        if(Instance.poolingObjQueue.Count > 0)
        {
           Bullet obj = Instance.poolingObjQueue.Dequeue();
           obj.transform.SetParent(null);
           obj.gameObject.SetActive(true);

           return obj;
        }
        else
        {
            Bullet newObj = Instance.CreateObj();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    public static void ReturnObj(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector2.zero;
        bullet.transform.SetParent(Instance.transform);

        Instance.poolingObjQueue.Enqueue(bullet);

    }

}
