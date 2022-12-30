using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshProUGUI ��� ��

public class CashText : MonoBehaviour
{
    private TextMeshProUGUI cashText;

    void Start()
    {
        cashText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        cashText.text = StatManager.Instance.Own_Mineral.ToString();
    }
}
