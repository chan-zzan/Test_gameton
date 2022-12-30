using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("���� �÷��� ���� �ð�")]
    [SerializeField]
    private int playTime;    // ���� �÷��� ���� �ð�
    
    [SerializeField]
    private int endTime;     // ���� ���� �ð�

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
        // �ʴ� �̳׶� ���� �ڷ�ƾ 
        StartCoroutine("MineMineralPerSeconds");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MineMineralPerSeconds()
    {
        yield return new WaitForSeconds(1.0f);
        StatManager.Instance.AddMineral(StatManager.Instance.Mine_MineralPerSeconds);
        StartCoroutine("MineMineralPerSeconds");
    }

}
