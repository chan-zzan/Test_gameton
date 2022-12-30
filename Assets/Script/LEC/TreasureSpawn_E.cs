using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawn_E : MonoBehaviour
{
    public GameObject treasure; // �������� ������
    public List<Transform> SpawnPoints; // ���� ��ġ
    public bool IsTreasureSpawn; // ���� ����

    public Vector3 curSpawnPos;

    public void TreasureSpawn()
    {
        if(!IsTreasureSpawn)
        {
            IsTreasureSpawn = true;

            GameObject obj = Instantiate(treasure); // �������� ����

            // ������ġ ����
            curSpawnPos = SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)].position;
            obj.transform.position = curSpawnPos;
        }
        else
        {
            // ĳ���Ͱ� ���������� ��ġ�� ã����
            //Vector3 dir = treasure.transform.position - GameManager_E.Instance.Player.transform.position;
            //RotData myData;

            //GameManager_E.Instance.Player.FindTreasure(dir, out myData);
        }
    }
}
