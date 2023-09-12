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

    private ProjectileBase CreateObj()//������ �Ѿ� ����
    {
        poolingObj = _character.CurrentProjectile;
        ProjectileBase temp = Instantiate(poolingObj, transform).GetComponent<ProjectileBase>();
        temp.gameObject.SetActive(false);
        return temp;
    }

    public void Init(int count)//������Ʈ Ǯ�� �Ѿ� ����
    {
        for(int i = 0; i < count; i++) 
        {
            poolingObjQueue.Enqueue(CreateObj());
        }
    }

    public void InitializePoolObject()//�Ѿ��� ����Ǿ����� ������ƮǮ�Ȱ� �߻�� �Ѿ� �ʱ�ȭ
    {
        GameObject[] projectiles;

        poolingObjQueue.Clear();

        projectiles = GameObject.FindGameObjectsWithTag("Projectile");//�̹� �߻�� �Ѿ� ����

        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }

        GameObject forDestroy = Instance.gameObject;//������Ʈ Ǯ �ȿ� �ִ� �Ѿ� ����
        foreach (Transform child in forDestroy.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public static ProjectileBase GetObject()//�Ѿ��� �߻��Ҷ� ������Ʈ Ǯ�ȿ��� �������� �����ϸ� ���� ����
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

    public static void ReturnObj(ProjectileBase projectile)//�߻�� �Ѿ��� �ٽ� ������Ʈ Ǯ������ ��ȯ
    {
        projectile.gameObject.SetActive(false);
        projectile.transform.position = Vector2.zero;
        projectile.transform.SetParent(Instance.transform);

        Instance.poolingObjQueue.Enqueue(projectile);

    }

}
