using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpaceShipManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;   // ���ּ� ���� �ؽ�Ʈ
    public TextMeshProUGUI cashPSText;  // �ʴ� �̳׶� ȹ�淮 �ؽ�Ʈ

    // ���ּ� ���� ����
    private int currentLevel;       // ���� ���ּ� ����
    private int getCashPerSeconds;  // ���� �ʴ� �̳׶� ȹ�淮
    private int levelUpCash;        // ������ �� �ʿ��� ��ȭ


    // �̱���
    private static SpaceShipManager instance;
    public static SpaceShipManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SpaceShipManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SpaceShipManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        var objs = FindObjectsOfType<SpaceShipManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }

        // -----�ʱ� ���� ���� (���̽� ����)
        // ����
        currentLevel = 1;
        levelText.text = currentLevel.ToString();
        // �ʴ� �̳׶� ȹ��
        getCashPerSeconds = 5;
        cashPSText.text = getCashPerSeconds.ToString();
    }

    // ���ּ� ���� ���� �Լ�
    public void AddLevel()
    {
        currentLevel += 1;
        levelText.text = currentLevel.ToString();
        // ���� ���� ����
        UpdateCashPerSeconds(); 
    }

    public void SetLevel(int value)
    {
        currentLevel = value;
        levelText.text = currentLevel.ToString();
        // ���� ���� ����
        UpdateCashPerSeconds();
    }
    public int GetLevel()
    {
        return currentLevel;
    }

    // �ʴ� �̳׶� ���� �Լ�
    public void UpdateCashPerSeconds()
    {
        getCashPerSeconds = currentLevel * 5;
        cashPSText.text = getCashPerSeconds.ToString();
    }

    public int GetCashPerSeconds()
    {
        return getCashPerSeconds;
    }


}
