using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public int playTime;    // ���� �÷��� ���� �ð�
    public int endTime;     // ���� ���� �ð�

    private bool timerDone;

    // �̱��� 
    private static TimeManager instance;
    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<TimeManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<TimeManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        var objs = FindObjectsOfType<TimeManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        // �� ����ÿ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        timerDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDone)
        {
            StartCoroutine("GetCashTimer");
            timerDone = false;
        }
    }
    
    IEnumerator GetCashTimer()
    {
        // 5�ʴ� �̳׶� ���귮
        yield return new WaitForSeconds(5.0f);
        SpaceShipManager.Instance.UpdateCashPerSeconds();
        timerDone = true;
    }
}
