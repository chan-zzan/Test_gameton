using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager_E : MonoBehaviour
{
    public float playTime = 0.0f;

    public TMPro.TMP_Text timer; // 시간 텍스트

    private void Update()
    {
        if (!GameManager_E.Instance.bossSpawn)
        {
            playTime += Time.deltaTime * 10;

            int sec = ((int)(playTime * 100) / 100) % 60;
            int min = ((int)(playTime * 100) / 100) / 60;

            string single_digit_sec = "";
            string single_digit_min = "";

            if (sec < 10)
            {
                single_digit_sec = "0";
            }

            if (min < 10)
            {
                single_digit_min = "0";
            }

            timer.text = single_digit_min + min + ":" + single_digit_sec + sec;

            if (min == 1 && sec == 30)
            {
                // 1분 30초 -> 보물상자 생성
                GameManager_E.Instance.treasureSpawner.TreasureSpawn();
            }
        }            
    }
}
