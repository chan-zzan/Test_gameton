using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("현재 플레이 중인 시간")]
    [SerializeField]
    private int playTime;    // 현재 플레이 중인 시간
    
    [SerializeField]
    private int endTime;     // 게임 종료 시간

    private bool timerDone;

    // 싱글톤 
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
        // 씬 변경시에도 파괴하지 않는다.
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        // 초당 미네랄 생산 코루틴 
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
