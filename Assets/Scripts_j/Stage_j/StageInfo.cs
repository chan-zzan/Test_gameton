using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageInfo : MonoBehaviour
{
    // 스테이지 정보를 담고있는 클래스
    // StageManager에서 관리

    // 스테이지 정보
    [Header("스테이지에 연동된 씬")]
    [SerializeField]
    private Scene stageScene;       // 연결된 씬

    private int stageNumber;        // 스테이지 번호 (스테이지 레벨로 사용될 수 있음)
    public int StageNumber { get { return stageNumber; } }

    private bool isUnLockEasyMode;  // 스테이지 이지모드 해금 여부
    public bool IsUnLockEasyMode { get { return isUnLockEasyMode; } }

    private bool isUnLockHardMode;  // 스테이지 하드모드 해금 여부
    public bool IsUnLockHardMode { get { return isUnLockHardMode; } }

    public enum ClearRank { RankC = 1, RankB, RankA} // 클리어 상태

    private ClearRank clearRankOfEasyMode;    // 이지 랭크 클리어 상태
    public ClearRank ClearRankOfEasyMode { get { return clearRankOfEasyMode; } }

    private ClearRank clearRankOfHardMode;    // 이지 랭크 클리어 상태
    public ClearRank ClearRankOfHardMode { get { return clearRankOfHardMode; } }

}
