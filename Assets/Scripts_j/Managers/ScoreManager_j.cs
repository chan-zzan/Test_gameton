using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager_j : MonoBehaviour
{
    // ���ھ� �Ŵ����� ���� ���ھ �����ϴ� �뵵�� ���ȴ�.
    // ���ھ� ���� ���� add, get �ϴ� �뵵�� ���.
    
    private static ScoreManager_j instance;
    public static ScoreManager_j Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<ScoreManager_j>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<ScoreManager_j>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        var objs = FindObjectsOfType<ScoreManager_j>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        // �� ����ÿ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }

    private int currentCash;    // ���� ��ȭ
    private int currentEVN;     // ���� ȯ������ (Environmental ���ڷ� EVN ���)
    
    // ��ȭ ���� add, get
    public void AddCash(int value)
    {
        currentCash += value;
    }

    public void TakeCash(int value)
    {
        currentCash -= value;
    }

    public int GetCash()
    {
        return currentCash;
    }

    // ȯ�� ���� ���� add, get 
    public void AddEVN(int value)
    {
        currentEVN += value;

        if(currentEVN >= 100)
        {
            BackGroundManager.Instance.ChangeImg();
        }
    }
    public int GetEVN()
    {
        return currentEVN;
    }


    void Start()
    {
        // �ʱ� ���� �ʱ�ȭ
        currentCash = 0;
        currentEVN = 0;
    }

    void Update()
    {

    }



    public void AddCashPerSeconds()
    {
        // ��ġ�� ��� ��ȭ �Լ�

        SpaceShipManager.Instance.GetCashPerSeconds();
    }

}
