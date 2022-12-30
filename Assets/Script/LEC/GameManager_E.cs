using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_E : MonoBehaviour
{
    #region �̱���
    private static GameManager_E instance = null;

    public static GameManager_E Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager_E>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "GameManager_E";
                    DontDestroyOnLoad(obj);
                    instance = obj.AddComponent<GameManager_E>();
                }
            }
            return instance;
        }
    }
    #endregion

    // ��ũ��Ʈ
    [Header("Script")]
    public Player_E Player;
    public ObjectPoolManager_E Pool;
    public TimeManager_E Time;
    public TreasureSpawn_E treasureSpawner;

    // ĳ���� ����
    //[Header("Character")]
    //public Stat stat;

    [Space(10)]

    // ���� ����
    [Header("Monster")]
    public MonsterSpawner_E monsterSpawner; // ���� ������
    public float monsterSpeed; // ���� �̵��ӵ�
    public bool bossSpawn = false; // ���� ���� ����    

    [Space(10)]

    // ����ü ����
    [Header("Projectile")]
    public ProjectileType curProjectileType; // ���� ����ü Ÿ��
    public float projectileSpeed; // ����ü �̵��ӵ�
    public float projectileShotTime; // ����ü �߻��ֱ�
    public int projectileNum = 1; // ����ü ����

    [Space(10)]

    // UI ����
    [Header("UI")]
    public Slider bossHP;
    public GameObject resultPopup;

    //[Space(10)]

    // ��Ÿ
    //[Header("Etc")]
    
}
