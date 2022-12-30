using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public int playTime;    // 현재 플레이 중인 시간
    public int endTime;     // 게임 종료 시간

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
        // 5초당 미네랄 생산량
        yield return new WaitForSeconds(5.0f);
        SpaceShipManager.Instance.UpdateCashPerSeconds();
        timerDone = true;
    }
}
