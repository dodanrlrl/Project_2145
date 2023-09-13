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
    private static ObjectPool _i;
    public static ObjectPool Instance
    {
        get
        {
            if (_i == null)
            {
                _i = FindObjectOfType<ObjectPool>();
                if (_i == null)
                    Debug.Log($"오브젝트 풀이 없습니다.");
            }
            return _i;
        }
    }
    public GameObject BaseBullet;
    private Queue<Bullet> _poolingObjQueue = new Queue<Bullet>();
    private Queue<Bullet> _changeBulletObjQueue = new Queue<Bullet>();//실험

    private void Awake()
    {
        if (_i == null)
            _i = this;
        else if (_i != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        MakeObjects(20);
    }

    private Bullet CreateObj()//총알 생성
    {
        Bullet bullet = Instantiate(BaseBullet, transform).GetComponent<Bullet>();
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public void MakeObjects(int count)//오브젝트 풀에 총알 장전
    {
        for (int i = 0; i < count; i++)
        {
            _poolingObjQueue.Enqueue(CreateObj());
        }
    }

    //***** 풀에서는 기본 총알만 빌려주고 총알에 관한 정보는 발사할 때 TopDownShooting에서 세팅할 예정******
    //public void InitializePoolObject()//총알이 변경되었을때 오브젝트풀안과 발사된 총알 초기화
    //{
    //    GameObject[] bullets;

    //    _poolingObjQueue.Clear();

    //    bullets = GameObject.FindGameObjectsWithTag("Bullet");//이미 발사된 총알 삭제

    //    foreach (GameObject bullet in bullets)
    //    {
    //        Destroy(bullet);
    //    }

    //    GameObject forDestroy = Instance.gameObject;//오브젝트 풀 안에 있는 총알 삭제
    //    foreach (Transform child in forDestroy.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //}

    public Bullet GetObject()//총알을 발사할때 오브젝트 풀안에서 꺼내오고 부족하면 새로 생성
    {
        if (Instance._poolingObjQueue.Count > 0)
        {
            Bullet obj = Instance._poolingObjQueue.Dequeue();
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

    public void ReturnObj(Bullet bullet)//발사된 총알을 다시 오브젝트 풀안으로 반환
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector2.zero;
        bullet.transform.SetParent(Instance.transform);

        Instance._poolingObjQueue.Enqueue(bullet);

    }

}
