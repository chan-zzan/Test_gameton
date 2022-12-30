using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductButton : MonoBehaviour
{
    [Header("���� �ð�")]
    public int productionTime;

    [Header("ȹ�� ��ȭ")]
    public int productionCash;

    [Header("ȹ�� ȯ�� ����")]
    public int productionEVN;

    [Header("��ǰ ������")]
    public GameObject myProduct;

    [Header("��ǰ ���� ��ġ")]
    public GameObject myProductList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        // ��ǰ ����
        GameObject product = Instantiate(myProduct, this.transform.position, Quaternion.identity);
        product.transform.SetParent(myProductList.transform);

        product.GetComponent<ProductInfo>().myTime = productionTime;
        product.GetComponent<ProductInfo>().myCash = productionCash;
        product.GetComponent<ProductInfo>().myEVN = productionEVN;
    }
}
