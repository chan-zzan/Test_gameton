using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Phase
{
    public int phase; // 단계
    public float spawnTime; // 스폰시간
    public GameObject spawnMonster; // 스폰몬스터
}

public class MonsterSpawner_E : MonoBehaviour
{
    public Transform[] spawnPoint;
    public Transform bossSpawnPoint; // 보스가 생성되는 위치

    // 보스 생성시 제한되는 맵
    public GameObject limitedMap_outside; // 외부
    public GameObject limitedMap_spawnPoint; // 생성 위치

    float timer;

    [SerializeField] Phase[] Phases; // 모든 페이즈의 내용들
    public Phase curPhase;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        curPhase = Phases[0];
        Spawn();
    }

    private void Update()
    {
        // 보스가 생성되기 전에만 진행
        if (!GameManager_E.Instance.bossSpawn)
        {
            timer += Time.deltaTime;

            curPhase = Phases[Mathf.Min(Mathf.FloorToInt(GameManager_E.Instance.Time.playTime / 30.0f), Phases.Length - 1)]; // 30초마다 페이즈 증가

            // 각 몬스터 별 스폰시간마다 몬스터 생성
            if (timer > curPhase.spawnTime && curPhase.phase < 6)
            {
                Spawn();
                timer = 0;
            }

            if (curPhase.phase == 6)
            {
                // 3분이 넘으면 보스 생성
                BossSpawn();
            }
        }
    }

    void Spawn()
    {
        // 몬스터 스폰
        Monster_E monster = GameManager_E.Instance.Pool._MonsterPools.Get();
        monster.transform.position = spawnPoint[Random.Range(2, spawnPoint.Length - 1)].position;
    }

    void BossSpawn()
    {
        GameManager_E.Instance.bossSpawn = true;
        GameManager_E.Instance.Time.timer.gameObject.SetActive(false); // 타이머 삭제

        // 보스 이외의 나머지 몬스터 없앰
        Monster_E[] monsters = GameManager_E.Instance.Pool.P_monsters.GetComponentsInChildren<Monster_E>();

        for (int i = 0; i < monsters.Length; i++)
        {
            Destroy(monsters[i].gameObject);
        }

        // 보스 생성
        Monster_E boss = GameManager_E.Instance.Pool._MonsterPools.Get();
        boss.transform.position = bossSpawnPoint.position;
        GameManager_E.Instance.bossHP.value = 1;
    }

    void LimitedMap()
    {

    }

}
