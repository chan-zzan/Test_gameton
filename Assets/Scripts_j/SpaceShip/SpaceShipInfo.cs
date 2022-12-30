using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceShipInfo : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI minepersecondsText;

    private void Update()
    {
        levelText.text = StatManager.Instance.Level_SpaceShip.ToString();
        minepersecondsText.text = StatManager.Instance.Mine_MineralPerSeconds.ToString();
    }
}
