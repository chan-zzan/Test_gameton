using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipLevelUpButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLevelUpButton()
    {
        // 재화 조건 추가
        SpaceShipManager.Instance.AddLevel();
    }
}
