using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshProUGUI 사용 시
using UnityEngine.SceneManagement;

public class GameStartSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI slider_perText;

    private void Start()
    {
        StartCoroutine("LoadSceneProcess");
    }

    private void Update()
    {
    }

    // 로딩 슬라이더 관련 코루틴
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("IdleMain_j");

        // 씬을 90퍼센트만 로드, true로 변경 시 남은 부분 로드 후 씬 변경
        // 로딩 시간이 너무 짧을 수 있기 때문에 페이크 로딩 방식으로 구현.
        op.allowSceneActivation = false;

        float timer = 0f;

        while(!op.isDone)   // 씬 로딩이 진행 중일 경우
        {
            // 유니티 엔진에 제어권을 넘김
            // 로딩 바가 차오르는 것을 표현하기 위함.
            yield return null;  

            if(op.progress < 0.9f)
            {
                slider.value = op.progress;
                int temp = (int)(slider.value);
                slider_perText.text = (temp * 100).ToString();
            }
            else 
            {
                // 로딩 진행도가 90% 이상일 경우 페이크 로딩 실행
                timer += Time.unscaledDeltaTime;
                slider.value = Mathf.Lerp(0.9f, 1f, timer);
                if (slider.value >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
