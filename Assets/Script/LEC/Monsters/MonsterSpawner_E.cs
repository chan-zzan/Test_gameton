using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Phase
{
    public int phase; // �ܰ�
    public float spawnTime; // �����ð�
    public GameObject spawnMonster; // ��������
}

public class MonsterSpawner_E : MonoBehaviour
{
    public Transform[] spawnPoint;
    public Transform bossSpawnPoint; // ������ �����Ǵ� ��ġ

    // ���� ������ ���ѵǴ� ��
    public GameObject limitedMap_outside; // �ܺ�
    public GameObject limitedMap_spawnPoint; // ���� ��ġ

    float timer;

    [SerializeField] Phase[] Phases; // ��� �������� �����
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
        // ������ �����Ǳ� ������ ����
        if (!GameManager_E.Instance.bossSpawn)
        {
            timer += Time.deltaTime;

            curPhase = Phases[Mathf.Min(Mathf.FloorToInt(GameManager_E.Instance.Time.playTime / 30.0f), Phases.Length - 1)]; // 30�ʸ��� ������ ����

            // �� ���� �� �����ð����� ���� ����
            if (timer > curPhase.spawnTime && curPhase.phase < 6)
            {
                Spawn();
                timer = 0;
            }

            if (curPhase.phase == 6)
            {
                // 3���� ������ ���� ����
                BossSpawn();
            }
        }
    }

    void Spawn()
    {
        // ���� ����
        Monster_E monster = GameManager_E.Instance.Pool._MonsterPools.Get();
        monster.transform.position = spawnPoint[Random.Range(2, spawnPoint.Length - 1)].position;
    }

    void BossSpawn()
    {
        GameManager_E.Instance.bossSpawn = true;
        GameManager_E.Instance.Time.timer.gameObject.SetActive(false); // Ÿ�̸� ����

        // ���� �̿��� ������ ���� ����
        Monster_E[] monsters = GameManager_E.Instance.Pool.P_monsters.GetComponentsInChildren<Monster_E>();

        for (int i = 0; i < monsters.Length; i++)
        {
            Destroy(monsters[i].gameObject);
        }

        // ���� ����
        Monster_E boss = GameManager_E.Instance.Pool._MonsterPools.Get();
        boss.transform.position = bossSpawnPoint.position;
        GameManager_E.Instance.bossHP.value = 1;
    }

    void LimitedMap()
    {

    }

}
