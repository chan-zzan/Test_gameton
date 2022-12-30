using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProductInfo : MonoBehaviour
{
    [Header("생산 시간")]
    public int myTime;

    [Header("획득 재화")]
    public int myCash;

    [Header("획득 환경점수")]
    public int myEVN;

    private int startTime;    // 제품 생산 시작시간
    private int currentTime;  // 현재 시간

    public GameObject harvestButton;    // 수확 버튼 오브젝트 제품. (제품 생산이 완료되면 활성화)


    void Start()
    {
        TimeSpan timestamp = DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0);
        startTime = (int)timestamp.TotalSeconds;
        Debug.Log(startTime);
    }

    void Update()
    {
        if (currentTime - startTime >= myTime)
        {
            Debug.Log("Enable Harvesting ! ");

            harvestButton.SetActive(true);
        }
        else
        {
            TimeSpan timestamp = DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0);
            currentTime = (int)timestamp.TotalSeconds;
        }
    }

    public void OnClickHarvestButton()
    {
        // 스코어 추가 (환경 점수, 재화)
        if(myEVN != 0)
        {
            ScoreManager_j.Instance.AddEVN(myEVN);
        }
        if(myCash != 0)
        {
            ScoreManager_j.Instance.AddCash(myCash);
        }

        // 생산품 제거
        Destroy(this.gameObject);
    }
}
