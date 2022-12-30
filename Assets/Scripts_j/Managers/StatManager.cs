using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    // �̱��� 
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
        // �� ����ÿ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }


    // ���� ���� ������
    // ���ּ�, ĳ����, �̳׶� �� �������� ������ �����Ѵ�.
    [Header("���ּ� ����")]
    [SerializeField]
    private int level_SpaceShip;    // ���ּ� ����
    public int Level_SpaceShip { get { return level_SpaceShip; }}

    [Header("�÷��̾� ����")]
    [SerializeField]
    private int level_Player;   // �÷��̾� ����
    public int Level_Player { get { return level_Player; } }

    [SerializeField]
    private float exp_Player;     // �÷��̾� ����ġ
    public float Exp_Player { get { return exp_Player; } }

    [SerializeField]
    private int stPoint_Player; // �÷��̾ ������ ���� ����Ʈ 
    public int StPoint_Player { get { return stPoint_Player; } }

    [SerializeField]
    private int atk_Player;     // �÷��̾� ���ݷ�
    public int Atk_Player { get { return atk_Player;} }

    [SerializeField]
    private int spd_Player;     // �÷��̾� �̵��ӵ�
    public int Spd_Player { get { return spd_Player; } }

    [SerializeField]
    private int amr_Player;     // �÷��̾� ����
    public int Amr_Player { get { return amr_Player; } }

    [SerializeField]
    private int hp_Player;      // �÷��̾� ü��
    public int Hp_Player { get { return hp_Player; } }

    [Header("��ȭ, ��ġ ���� ����")]
    [SerializeField]
    private float own_Mineral;  // ������ �̳׶�
    public float Own_Mineral { get { return own_Mineral; } }

    [SerializeField]
    private float current_EVN;  // ���� ȯ������
    public float Current_EVN { get { return current_EVN; } }


    [Header("���ݿ� ���� �ɷ�ġ(�б� ����)")]
    [SerializeField]
    private float mine_MineralPerSeconds;   // �ʴ� ȹ�� �̳׶�
    public float Mine_MineralPerSeconds { get { return mine_MineralPerSeconds; } }

    [SerializeField]
    private float requiredExp;      // ������ �� �ʿ� ����ġ
    public float RequiredExp { get { return requiredExp; } }


    // Start is called before the first frame update
    void Start()
    {
        LoadStat();
    }

    // ���� �� ���� �Լ�
    public void AddMineral(float amount)        // �̳׶� �߰�
    {
        own_Mineral += amount;
    }
    public void AddPlayerLevel(int amount)      // �÷��̾� ���� ��
    {
        level_Player += amount;
        stPoint_Player += (amount * 3);   // ���� ����Ʈ�� ������ 3
        requiredExp = level_Player * 5;   // �ʿ� ����ġ ����
        exp_Player = 0f;                  // ����ġ �ʱ�ȭ
    }
    public void AddPlayerEXP(float amount)        // �÷��̾� ����ġ ��
    {
        if (amount > 0)
        {
            if (exp_Player + amount < requiredExp)   // �ʿ� ����ġ ���� ���� ���
            {
                // ����ġ �߰�
                exp_Player += amount;
            }
            else                                    // ����ġ�� �ʰ��� ���
            {
                AddPlayerLevel(1);  // 1 ������
                AddPlayerEXP(exp_Player + amount - requiredExp);    // ������ ����ġ �ٽ� �߰�
            }
        }
    }
    public void AddSpaceShipLevel(int amount)   // ���ּ� ���� ��
    {
        level_SpaceShip += amount;
        mine_MineralPerSeconds = level_SpaceShip * 5;   // �ʴ� �̳׶� ���귮�� ���ּ� ���� *5


    }


    public void AddEVN(float amount)
    {
        current_EVN += amount;
    }

    // �ʱ� ���� (������ ���� ó�� ���� ������ ���)
    public void InitialSetting()
    {
        // ���ּ� �ʱ� ����
        level_SpaceShip = 1;

        // ���� �ʱ� ����
        level_Player = 1;
        exp_Player = 0f;
        stPoint_Player = 0;
        atk_Player = 5;
        spd_Player = 1;
        amr_Player = 0;
        hp_Player = 100;

        // ��ȭ �ʱ� ����
        own_Mineral = 0;

        // �ɷ�ġ ����
        mine_MineralPerSeconds = level_SpaceShip * 5f;  // �ʴ� �̳׶� ȹ�淮
        requiredExp = (float)(level_Player * 5f);    // ������ �� �ʿ� ����ġ (�ӽ�:����*5)
    }

    // ������ �ε�
    public void LoadStat()
    {
        // ������ �Ŵ����� ���ؼ� ����� ���� ������ �ҷ���

        // ����� ���� �����Ͱ� ���� ���
        InitialSetting();
    }



}
