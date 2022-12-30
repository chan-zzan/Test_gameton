using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshProUGUI 사용 시
using UnityEngine.SceneManagement;

public class GameStartSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI slider_per;

    private void Start()
    {
        StartCoroutine("Loading_Start");
    }

    private void Update()
    {
        if(slider.value >= 1)
        {   
            StopCoroutine("Loading_Start");
            // 메인 게임 씬 오픈
            SceneManager.LoadScene("IdleMain_j");
        }
    }

    // 로딩 슬라이더 관련 코루틴
    IEnumerator Loading_Start()
    {
         while(slider.value < 1)
        {
            // 테스트용 5초 로딩
            yield return new WaitForSeconds(0.1f);
            slider.value += 0.02f;  // 슬라이더 바 
            int i_value = (int)(slider.value * 100);    // 퍼센트 값 정수형 변환
            slider_per.text = i_value.ToString()+"%";   // 퍼센트 텍스트 출력
        }
    }
}
