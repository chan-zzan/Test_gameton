using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawn_E : MonoBehaviour
{
    public GameObject treasure; // 보물상자 프리팹
    public List<Transform> SpawnPoints; // 생성 위치
    public bool IsTreasureSpawn; // 생성 여부

    public Vector3 curSpawnPos;

    public void TreasureSpawn()
    {
        if(!IsTreasureSpawn)
        {
            IsTreasureSpawn = true;

            GameObject obj = Instantiate(treasure); // 보물상자 생성

            // 생성위치 설정
            curSpawnPos = SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)].position;
            obj.transform.position = curSpawnPos;
        }
        else
        {
            // 캐릭터가 보물상자의 위치를 찾도록
            //Vector3 dir = treasure.transform.position - GameManager_E.Instance.Player.transform.position;
            //RotData myData;

            //GameManager_E.Instance.Player.FindTreasure(dir, out myData);
        }
    }
}
