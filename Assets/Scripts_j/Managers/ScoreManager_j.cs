using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager_j : MonoBehaviour
{
    // 스코어 매니저는 게임 스코어를 관리하는 용도로 사용된다.
    // 스코어 관련 값을 add, get 하는 용도로 사용.
    
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
        // 씬 변경시에도 파괴하지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    private int currentCash;    // 현재 재화
    private int currentEVN;     // 현재 환경점수 (Environmental 약자로 EVN 사용)
    
    // 재화 관련 add, get
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

    // 환경 점수 관련 add, get 
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
        // 초기 점수 초기화
        currentCash = 0;
        currentEVN = 0;
    }

    void Update()
    {

    }



    public void AddCashPerSeconds()
    {
        // 방치로 얻는 재화 함수

        SpaceShipManager.Instance.GetCashPerSeconds();
    }

}
