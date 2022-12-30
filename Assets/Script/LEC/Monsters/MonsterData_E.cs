using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "MonsterData", order = int.MinValue)] // ��ũ���ͺ� ������Ʈ�� ���� �� �ִ� ��� ����
public class MonsterData_E : ScriptableObject
{
    [SerializeField]
    private float hp; // ü��

    [SerializeField]
    private float damage; // ���ݷ�

    [SerializeField]
    private float moveSpeed; // �̵��ӵ�


    public float Hp
    {
        get { return hp; }
    }

    public float Damage
    {
        get { return damage; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
}
