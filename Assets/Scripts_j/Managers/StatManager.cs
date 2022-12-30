using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    // 싱글톤 
    private static StatManager instance;
    public static StatManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<StatManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<StatManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        var objs = FindObjectsOfType<StatManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        // 씬 변경시에도 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }


    // 게임 스텟 관리자
    // 우주선, 캐릭터, 미네랄 등 전반적인 스텟을 관리한다.
    [Header("우주선 스텟")]
    [SerializeField]
    private int level_SpaceShip;    // 우주선 레벨
    public int Level_SpaceShip { get { return level_SpaceShip; }}

    [Header("플레이어 스텟")]
    [SerializeField]
    private int level_Player;   // 플레이어 레벨
    public int Level_Player { get { return level_Player; } }

    [SerializeField]
    private float exp_Player;     // 플레이어 경험치
    public float Exp_Player { get { return exp_Player; } }

    [SerializeField]
    private int stPoint_Player; // 플레이어가 소지한 스텟 포인트 
    public int StPoint_Player { get { return stPoint_Player; } }

    [SerializeField]
    private int atk_Player;     // 플레이어 공격력
    public int Atk_Player { get { return atk_Player;} }

    [SerializeField]
    private int spd_Player;     // 플레이어 이동속도
    public int Spd_Player { get { return spd_Player; } }

    [SerializeField]
    private int amr_Player;     // 플레이어 방어력
    public int Amr_Player { get { return amr_Player; } }

    [SerializeField]
    private int hp_Player;      // 플레이어 체력
    public int Hp_Player { get { return hp_Player; } }

    [Header("재화, 수치 관련 스텟")]
    [SerializeField]
    private float own_Mineral;  // 소지한 미네랄
    public float Own_Mineral { get { return own_Mineral; } }

    [SerializeField]
    private float current_EVN;  // 현재 환경점수
    public float Current_EVN { get { return current_EVN; } }


    [Header("스텟에 따른 능력치(읽기 전용)")]
    [SerializeField]
    private float mine_MineralPerSeconds;   // 초당 획득 미네랄
    public float Mine_MineralPerSeconds { get { return mine_MineralPerSeconds; } }

    [SerializeField]
    private float requiredExp;      // 레벨업 시 필요 경험치
    public float RequiredExp { get { return requiredExp; } }


    // Start is called before the first frame update
    void Start()
    {
        LoadStat();
    }

    // 스텟 업 관련 함수
    public void AddMineral(float amount)        // 미네랄 추가
    {
        own_Mineral += amount;
    }
    public void AddPlayerLevel(int amount)      // 플레이어 레벨 업
    {
        level_Player += amount;
        stPoint_Player += (amount * 3);   // 스텟 포인트는 레벨당 3
        requiredExp = level_Player * 5;   // 필요 경험치 갱신
        exp_Player = 0f;                  // 경험치 초기화
    }
    public void AddPlayerEXP(float amount)        // 플레이어 경험치 업
    {
        if (amount > 0)
        {
            if (exp_Player + amount < requiredExp)   // 필요 경험치 보다 작은 경우
            {
                // 경험치 추가
                exp_Player += amount;
            }
            else                                    // 경험치가 초과한 경우
            {
                AddPlayerLevel(1);  // 1 레벨업
                AddPlayerEXP(exp_Player + amount - requiredExp);    // 여분의 경험치 다시 추가
            }
        }
    }
    public void AddSpaceShipLevel(int amount)   // 우주선 레벨 업
    {
        level_SpaceShip += amount;
        mine_MineralPerSeconds = level_SpaceShip * 5;   // 초당 미네랄 생산량은 우주선 레벨 *5


    }


    public void AddEVN(float amount)
    {
        current_EVN += amount;
    }

    // 초기 세팅 (데이터 없이 처음 게임 시작할 경우)
    public void InitialSetting()
    {
        // 우주선 초기 세팅
        level_SpaceShip = 1;

        // 유저 초기 세팅
        level_Player = 1;
        exp_Player = 0f;
        stPoint_Player = 0;
        atk_Player = 5;
        spd_Player = 1;
        amr_Player = 0;
        hp_Player = 100;

        // 재화 초기 세팅
        own_Mineral = 0;

        // 능력치 세팅
        mine_MineralPerSeconds = level_SpaceShip * 5f;  // 초당 미네랄 획득량
        requiredExp = (float)(level_Player * 5f);    // 레벨업 시 필요 경험치 (임시:레벨*5)
    }

    // 데이터 로드
    public void LoadStat()
    {
        // 데이터 매니저를 통해서 저장된 유저 데이터 불러옴

        // 저장된 유저 데이터가 없을 경우
        InitialSetting();
    }



}
