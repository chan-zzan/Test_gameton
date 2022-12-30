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
        // ���ӽ��� ��ư Ŭ�� ��
        titleUI.SetActive(false);    // Ÿ��Ʋ UI ��Ȱ��ȭ
        maingameUI.SetActive(true);  // ���ΰ��� UI Ȱ��ȭ

        // ������ �ε� (����� ������ - ����, ���� ��������)
        WaveData waveData = gameDataManager.LoadData("/Data_Game/GameDatas/Wave1.json");
        waveManager.RegisterWave(waveData);
    }
    public void OnClickLoadButton()
    {
        // �ҷ����� ��ư Ŭ�� ��
        titleUI.SetActive(false);   // Ÿ��Ʋ UI ��Ȱ��ȭ
        maingameUI.SetActive(true); // ���ΰ��� UI Ȱ��ȭ

        // ������ �ε� (����� ������ - ����)

    }
    public void OnClickQuitButton()
    {
        // �������� ��ư Ŭ�� ��

    }
}
