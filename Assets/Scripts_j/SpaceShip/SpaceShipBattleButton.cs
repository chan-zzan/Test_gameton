using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipBattleButton : MonoBehaviour
{
    [Header("��ư Ŭ�� �� UI ���� OPEN/CLOSE")]
    public GameObject[] openObejcts;    // open �� ������Ʈ  (�������� ���� �׷�)
    public GameObject[] closeObjects;   // close �� ������Ʈ (���� �����ִ� ���� �׷�)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RenewUI()
    {
        for(int i=0; i< closeObjects.Length; i++)
        {
            closeObjects[i].SetActive(true);
        }
        for (int i = 0; i < openObejcts.Length; i++)
        {
            openObejcts[i].SetActive(true);
        }
    }

    public void OnClickBattleButton()
    {
        RenewUI();
    }
}
