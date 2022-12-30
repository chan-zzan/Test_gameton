using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUIButton : MonoBehaviour
{
    [Header("클릭 시 열 창")]
    public GameObject openPopUpUI;

    [Header("클릭 시 닫을 창")]
    public GameObject closePopUpUI;

    public void OnClickButton()
    {
        if (openPopUpUI)
        {
            openPopUpUI.SetActive(true);
        }
        if (closePopUpUI)
        {
            closePopUpUI.SetActive(false);
        }
    }
}
