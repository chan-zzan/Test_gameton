using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    [Header("클릭으로 재화 수급 가능 여부")]
    public bool enableClick = true;

    [Header("클릭 당 획득 재화")]
    public int clickMineralAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && enableClick)
        {
            StatManager.Instance.AddMineral(clickMineralAmount);
        }
    }
}
