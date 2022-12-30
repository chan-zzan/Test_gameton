using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public GameDataManager gameDataManager;

    [HideInInspector]
    public WaveManager waveManager;

    [Header("Canvas")]
    public GameObject titleUI;
    public GameObject maingameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        // 게임시작 버튼 클릭 시
        titleUI.SetActive(false);    // 타이틀 UI 비활성화
        maingameUI.SetActive(true);  // 메인게임 UI 활성화

        // 데이터 로드 (저장된 데이터 - 게임, 시작 스테이지)
        WaveData waveData = gameDataManager.LoadData("/Data_Game/GameDatas/Wave1.json");
        waveManager.RegisterWave(waveData);
    }
    public void OnClickLoadButton()
    {
        // 불러오기 버튼 클릭 시
        titleUI.SetActive(false);   // 타이틀 UI 비활성화
        maingameUI.SetActive(true); // 메인게임 UI 활성화

        // 데이터 로드 (저장된 데이터 - 유저)

    }
    public void OnClickQuitButton()
    {
        // 게임종료 버튼 클릭 시

    }
}
