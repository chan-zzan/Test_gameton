using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshProUGUI ��� ��
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
            // ���� ���� �� ����
            SceneManager.LoadScene("IdleMain_j");
        }
    }

    // �ε� �����̴� ���� �ڷ�ƾ
    IEnumerator Loading_Start()
    {
         while(slider.value < 1)
        {
            // �׽�Ʈ�� 5�� �ε�
            yield return new WaitForSeconds(0.1f);
            slider.value += 0.02f;  // �����̴� �� 
            int i_value = (int)(slider.value * 100);    // �ۼ�Ʈ �� ������ ��ȯ
            slider_per.text = i_value.ToString()+"%";   // �ۼ�Ʈ �ؽ�Ʈ ���
        }
    }
}
