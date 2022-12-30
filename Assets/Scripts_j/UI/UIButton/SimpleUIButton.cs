using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUIButton : MonoBehaviour
{
    [Header("Ŭ�� �� �� â")]
    public GameObject openPopUpUI;

    [Header("Ŭ�� �� ���� â")]
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
