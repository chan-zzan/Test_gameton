using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductButton : MonoBehaviour
{
    [Header("생산 시간")]
    public int productionTime;

    [Header("획득 재화")]
    public int productionCash;

    [Header("획득 환경 점수")]
    public int productionEVN;

    [Header("제품 프리팹")]
    public GameObject myProduct;

    [Header("제품 생성 위치")]
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
        // 제품 생성
        GameObject product = Instantiate(myProduct, this.transform.position, Quaternion.identity);
        product.transform.SetParent(myProductList.transform);

        product.GetComponent<ProductInfo>().myTime = productionTime;
        product.GetComponent<ProductInfo>().myCash = productionCash;
        product.GetComponent<ProductInfo>().myEVN = productionEVN;
    }
}
