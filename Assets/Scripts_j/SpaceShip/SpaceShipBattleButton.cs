using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipBattleButton : MonoBehaviour
{
    [Header("버튼 클릭 시 UI 갱신 OPEN/CLOSE")]
    public GameObject[] openObejcts;    // open 할 오브젝트  (스테이지 선택 그룹)
    public GameObject[] closeObjects;   // close 할 오브젝트 (현재 열려있는 메인 그룹)

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
