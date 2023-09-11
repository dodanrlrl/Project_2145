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
                    Debug.Log($"������Ʈ Ǯ�� �����ϴ�.");
            }
            return _i;
        }
    }
    private GameObject poolingObj;
    private Queue<Bullet> poolingObjQueue = new Queue<Bullet>();
    private Queue<Bullet> changeBulletObjQueue = new Queue<Bullet>();//����

    private void Awake()
    {
        if (_i == null)
            _i = this;
        else if (_i != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        MakeObjects(20);
    }

    private Bullet CreateObj()//������ �Ѿ� ����
    {
        TopDownCharacter character = GameManager.Instance.player.GetComponent<TopDownCharacter>();

        poolingObj = character.CurrentProjectile;
        Bullet temp = Instantiate(poolingObj, transform).GetComponent<Bullet>();
        temp.gameObject.SetActive(false);
        return temp;
    }

    public void MakeObjects(int count)//������Ʈ Ǯ�� �Ѿ� ����
    {
        for(int i = 0; i < count; i++) 
        {
            poolingObjQueue.Enqueue(CreateObj());
        }
    }

    public void InitializePoolObject()//�Ѿ��� ����Ǿ����� ������ƮǮ�Ȱ� �߻�� �Ѿ� �ʱ�ȭ
    {
        GameObject[] bullets;

        poolingObjQueue.Clear();

        bullets = GameObject.FindGameObjectsWithTag("Bullet");//�̹� �߻�� �Ѿ� ����

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        GameObject forDestroy = Instance.gameObject;//������Ʈ Ǯ �ȿ� �ִ� �Ѿ� ����
        foreach (Transform child in forDestroy.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public static Bullet GetObject()//�Ѿ��� �߻��Ҷ� ������Ʈ Ǯ�ȿ��� �������� �����ϸ� ���� ����
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

    public void ReturnObj(Bullet bullet)//�߻�� �Ѿ��� �ٽ� ������Ʈ Ǯ������ ��ȯ
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector2.zero;
        bullet.transform.SetParent(Instance.transform);

        Instance.poolingObjQueue.Enqueue(bullet);

    }

}
