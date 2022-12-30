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
        timer += Time.deltaTime;

        curPhase = Phases[Mathf.Min(Mathf.FloorToInt(GameManager_E.Instance.Time.playTime / 30.0f), Phases.Length - 1)]; // 30�ʸ��� ������ ����

        // �� ���� �� �����ð����� ���� ����
        if (timer > curPhase.spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        // ���� ����
        Monster_E monster = GameManager_E.Instance.Pool._MonsterPools.Get();
        monster.transform.position = spawnPoint[Random.Range(2, spawnPoint.Length - 1)].position;
    }
}
