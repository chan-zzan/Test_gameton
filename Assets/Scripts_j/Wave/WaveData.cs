using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData
{
    public Wave[] waveList;

    public int iWaveCount;  // ���� ���̺� ī����

    public int iNormalZombieCount;
    public int iPowerZombieCount;
    public int iTankerZombieCount;
    public int iSpeedZombieCount;
    
    public WaveData()
    {
        iWaveCount = 1;

        iNormalZombieCount = 3;
        iPowerZombieCount = 1;
        iTankerZombieCount = 1;
        iSpeedZombieCount = 1;
    }

    public class Wave
    {


    }



    public void PrintData()
    {
        Debug.Log("------- ���̺� ������ --------");
        Debug.Log("���� ���̺� : " + iWaveCount);
        Debug.Log("Normal Zombie : " + iNormalZombieCount);
        Debug.Log("Power Zombie : " + iPowerZombieCount);
        Debug.Log("Tanker Zombie : " + iTankerZombieCount);
        Debug.Log("Speed Zombie : " + iSpeedZombieCount);
        Debug.Log("-----------------------------");
    }
}
