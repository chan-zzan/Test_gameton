using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshProUGUI ��� ��
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

    // �ε� �����̴� ���� �ڷ�ƾ
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("IdleMain_j");

        // ���� 90�ۼ�Ʈ�� �ε�, true�� ���� �� ���� �κ� �ε� �� �� ����
        // �ε� �ð��� �ʹ� ª�� �� �ֱ� ������ ����ũ �ε� ������� ����.
        op.allowSceneActivation = false;

        float timer = 0f;

        while(!op.isDone)   // �� �ε��� ���� ���� ���
        {
            // ����Ƽ ������ ������� �ѱ�
            // �ε� �ٰ� �������� ���� ǥ���ϱ� ����.
            yield return null;  

            if(op.progress < 0.9f)
            {
                slider.value = op.progress;
                int temp = (int)(slider.value);
                slider_perText.text = (temp * 100).ToString();
            }
            else 
            {
                // �ε� ���൵�� 90% �̻��� ��� ����ũ �ε� ����
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
