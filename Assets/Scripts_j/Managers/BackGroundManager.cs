using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    // ΩÃ±€≈Ê 
    private static BackGroundManager instance;
    public static BackGroundManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<BackGroundManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<BackGroundManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        var objs = FindObjectsOfType<BackGroundManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
    }

    public Image currentImg;

    public Sprite grassgroundImg;  // ¿‹µπÁ ¿ÃπÃ¡ˆ
    public void ChangeImg()
    {
        currentImg.sprite = grassgroundImg;
    }
}
