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
        timer += Time.deltaTime;

        curPhase = Phases[Mathf.Min(Mathf.FloorToInt(GameManager_E.Instance.Time.playTime / 30.0f), Phases.Length - 1)]; // 30초마다 페이즈 증가

        // 각 몬스터 별 스폰시간마다 몬스터 생성
        if (timer > curPhase.spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        // 몬스터 스폰
        Monster_E monster = GameManager_E.Instance.Pool._MonsterPools.Get();
        monster.transform.position = spawnPoint[Random.Range(2, spawnPoint.Length - 1)].position;
    }
}
