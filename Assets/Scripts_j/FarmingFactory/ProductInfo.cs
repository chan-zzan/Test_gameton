using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProductInfo : MonoBehaviour
{
    [Header("���� �ð�")]
    public int myTime;

    [Header("ȹ�� ��ȭ")]
    public int myCash;

    [Header("ȹ�� ȯ������")]
    public int myEVN;

    private int startTime;    // ��ǰ ���� ���۽ð�
    private int currentTime;  // ���� �ð�

    public GameObject harvestButton;    // ��Ȯ ��ư ������Ʈ ��ǰ. (��ǰ ������ �Ϸ�Ǹ� Ȱ��ȭ)


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
        // ���ھ� �߰� (ȯ�� ����, ��ȭ)
        if(myEVN != 0)
        {
            ScoreManager_j.Instance.AddEVN(myEVN);
        }
        if(myCash != 0)
        {
            ScoreManager_j.Instance.AddCash(myCash);
        }

        // ����ǰ ����
        Destroy(this.gameObject);
    }
}
