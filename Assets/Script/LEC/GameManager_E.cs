using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_E : MonoBehaviour
{
    #region 싱글톤
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

    // 스크립트
    [Header("Script")]
    public Player_E Player;
    public ObjectPoolManager_E Pool;
    public TimeManager_E Time;
    public TreasureSpawn_E treasureSpawner;

    // 캐릭터 관련
    //[Header("Character")]
    //public Stat stat;

    [Space(10)]

    // 몬스터 관련
    [Header("Monster")]
    public MonsterSpawner_E monsterSpawner; // 몬스터 생성자
    public float monsterSpeed; // 몬스터 이동속도
    public bool bossSpawn = false; // 보스 등장 여부    

    [Space(10)]

    // 투사체 관련
    [Header("Projectile")]
    public ProjectileType curProjectileType; // 현재 투사체 타입
    public float projectileSpeed; // 투사체 이동속도
    public float projectileShotTime; // 투사체 발사주기
    public int projectileNum = 1; // 투사체 개수

    [Space(10)]

    // UI 관련
    [Header("UI")]
    public Slider bossHP;
    public GameObject resultPopup;

    //[Space(10)]

    // 기타
    //[Header("Etc")]
    
}
