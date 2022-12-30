using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_E : MonoBehaviour
{
    public List<GameObject> monsters = new List<GameObject>();

    public Transform nearestMonster; // ���� ���� �����̿� �ִ� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ ���͸� ����Ʈ�� ����
        if(collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            monsters.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���� ���� ������ ���� ���ʹ� ����Ʈ���� ����
        monsters.Remove(collision.gameObject);
    }

    private void Update()
    {
        if (monsters.Count > 0)
        {
            FindNearestMonster();
            Debug.DrawLine(GameManager_E.Instance.Player.transform.position, nearestMonster.position, Color.red);
        }
        else
        {
            nearestMonster = null;
        }
    }

    void FindNearestMonster()
    {
        float nearestDist = 9999.9f; // �ּҰŸ�

        // ����Ʈ ������ ���� ����� ���͸� ã��
        foreach (GameObject mon in monsters)
        {
            float curDist = (mon.transform.position - GameManager_E.Instance.Player.transform.position).magnitude; // ���� ���Ϳ� ĳ���� ������ �Ÿ�

            nearestDist = nearestDist > curDist ? curDist : nearestDist; // �ּڰ� ����

            if (nearestDist == curDist)
            {
                // ������ �Ͼ ���
                nearestMonster = mon.transform;
            }
        }
    }
}
