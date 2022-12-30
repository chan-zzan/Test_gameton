using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // �̱��� 
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
        // �� ����ÿ��� �ı����� �ʴ´�.
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
        //// �������� ��ư�� �� ����
        //int lengthOfStage = GameObject.FindGameObjectsWithTag("StageButton").Length;

        //if(stageInfos.Count == 0)   // �������� ����Ʈ�� ����ִ� ���
        //{
        //    // ���� ���
        //    for(int i =0; i<lengthOfStage; i++)
        //    {
        //        GameObject.Find
        //    }
        //}
    }

    void LoadStage(Scene targetScene)
    {
        // �� �ε�
        SceneManager.LoadScene(targetScene.path);
    }

    // �������� �ر� �Լ� (StatManager�� AddSpaceShipLevel �Լ����� ȣ��)
    // �Ű����� : start_stage ���� end_stage���� �ر�
    void UnLockStageButton(int startStage, int endStage)
    {

    }
}
