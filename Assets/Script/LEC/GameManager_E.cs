using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Player_E Player;
    public ObjectPoolManager_E Pool;
    public TimeManager_E Time;

    // ĳ���� ����
    //[Header("Character")]
    //public Stat stat;

    //[Space(10)]

    // ���� ����
    [Header("Monster")]
    public MonsterSpawner_E monsterSpawner; // ���� ������
    public float monsterSpeed; // ���� �̵��ӵ�

    [Space(10)]

    // ����ü ����
    [Header("Projectile")]
    public ProjectileType curProjectileType; // ���� ����ü Ÿ��
    public float projectileSpeed; // ����ü �̵��ӵ�
    public float projectileShotTime; // ����ü �߻��ֱ�
    public int projectileNum = 1; // ����ü ����

}
