using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //// Json ����ȭ
        //JsonExample jtest = new JsonExample();
        //string jsondata = JsonConvert.SerializeObject(jtest);
        //Debug.Log(jsondata);

        //// Json ������Ʈȭ
        //JsonExample jtest2 = JsonConvert.DeserializeObject<JsonExample>(jsondata);
        //jtest2.print();

        //// 
    }

    // Update is called once per frame
    void Update()
    {

    }
}


public class JsonExample
{
    public int i;
    

    public JsonExample()
    {
        i = 1;
    }

    public void print()
    {
        Debug.Log("i = " + i);
    }

}
