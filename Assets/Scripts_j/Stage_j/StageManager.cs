using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // 싱글톤 
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<StageManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<StageManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        var objs = FindObjectsOfType<StageManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        // 씬 변경시에도 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    private List<StageInfo> stageInfos;

    // Start is called before the first frame update
    void Start()
    {
        stageInfos = new List<StageInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RegistStage()
    {
        //// 스테이지 버튼의 총 개수
        //int lengthOfStage = GameObject.FindGameObjectsWithTag("StageButton").Length;

        //if(stageInfos.Count == 0)   // 스테이지 리스트가 비어있는 경우
        //{
        //    // 최초 등록
        //    for(int i =0; i<lengthOfStage; i++)
        //    {
        //        GameObject.Find
        //    }
        //}
    }

    void LoadStage(Scene targetScene)
    {
        // 씬 로드
        SceneManager.LoadScene(targetScene.path);
    }

    // 스테이지 해금 함수 (StatManager의 AddSpaceShipLevel 함수에서 호출)
    // 매개변수 : start_stage 부터 end_stage까지 해금
    void UnLockStageButton(int startStage, int endStage)
    {

    }
}
