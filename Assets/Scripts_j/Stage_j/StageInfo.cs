using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageInfo : MonoBehaviour
{
    // �������� ������ ����ִ� Ŭ����
    // StageManager���� ����

    // �������� ����
    [Header("���������� ������ ��")]
    [SerializeField]
    private Scene stageScene;       // ����� ��

    private int stageNumber;        // �������� ��ȣ (�������� ������ ���� �� ����)
    public int StageNumber { get { return stageNumber; } }

    private bool isUnLockEasyMode;  // �������� ������� �ر� ����
    public bool IsUnLockEasyMode { get { return isUnLockEasyMode; } }

    private bool isUnLockHardMode;  // �������� �ϵ��� �ر� ����
    public bool IsUnLockHardMode { get { return isUnLockHardMode; } }

    public enum ClearRank { RankC = 1, RankB, RankA} // Ŭ���� ����

    private ClearRank clearRankOfEasyMode;    // ���� ��ũ Ŭ���� ����
    public ClearRank ClearRankOfEasyMode { get { return clearRankOfEasyMode; } }

    private ClearRank clearRankOfHardMode;    // ���� ��ũ Ŭ���� ����
    public ClearRank ClearRankOfHardMode { get { return clearRankOfHardMode; } }

}
