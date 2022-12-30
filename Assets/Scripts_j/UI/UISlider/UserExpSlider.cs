using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserExpSlider : MonoBehaviour
{
    public TextMeshProUGUI userLevelText;       // 유저 레벨 텍스트
    public TextMeshProUGUI userExpPercentText;  // 유저 경험치 퍼센트 텍스트
    public Slider userExpSlider;                // 유저 경험치 바 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        userExpSlider.value = StatManager.Instance.Exp_Player/StatManager.Instance.RequiredExp;
        userLevelText.text = "Lv." + StatManager.Instance.Level_Player.ToString();
        int expPercent = (int)(userExpSlider.value * 100);
        userExpPercentText.text = expPercent.ToString();    
    }
}
