using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public ZombieData zombieData;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintZombieData(bool enable)
    {
        // ���� �� enable = true   (ȣ��:ZombieSpawner)
        // �ı� �� enable = false  (ȣ��:this)
        if (enable)
        {
            Debug.Log("-------------- ���� ----------------");
            Debug.Log("�����̸� :: " + zombieData.ZombieName);
            Debug.Log("ü�� :: " + zombieData.Hp);
            Debug.Log("���ݷ� :: " + zombieData.Damage);
            Debug.Log("�̵��ӵ� :: " + zombieData.MoveSpeed);
            Debug.Log("-------------------------------------");
        }
        else 
        {
            Debug.Log("-------------- �ı� ----------------");
            Debug.Log("�����̸� :: " + zombieData.ZombieName);
            Debug.Log("-------------------------------------");
        }
    }
    private void OnDestroy()
    {
        PrintZombieData(false);
    }
}
