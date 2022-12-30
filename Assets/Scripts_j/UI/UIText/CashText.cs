using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshProUGUI »ç¿ë ½Ã

public class CashText : MonoBehaviour
{
    private TextMeshProUGUI cashText;

    void Start()
    {
        cashText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        cashText.text = ScoreManager_j.Instance.GetCash().ToString();
    }
}
