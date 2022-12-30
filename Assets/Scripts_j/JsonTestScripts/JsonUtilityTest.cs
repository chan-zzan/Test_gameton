using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtilityTest : MonoBehaviour
{
    // ��ƿ��Ƽ ����
    // �⺻���� ������Ÿ��, ����Ʈ, �迭 � ���� �ø������� ���
    // ��ųʸ�, ���� Ŭ���� �� ����
    // System.Serializable �� �ܺ� ���̺귯���� ���� �ø�������� (��ųʸ��� �ƿ� �������� ����)
    
    // Start is called before the first frame update
    void Start()
    {
        //// ��ƿ��Ƽ �׽�Ʈ
        //JsonExample jtest = new JsonExample();
        //string jsondata = JsonUtility.ToJson(jtest);
        //Debug.Log(jsondata);

        //JsonExample jtest2 = JsonUtility.FromJson<JsonExample>(jsondata);
        //jtest2.print();

        //// ������Ʈ �ø�������� �׽�Ʈ
        GameObject obj = new GameObject();
        var test1 = obj.AddComponent<TestMono>();
        test1.v3 /= 10;       // ��ø�������� ���� ������ ���� �̸� �ʱ�ȭ �ؾ���.
        obj.AddComponent<TestMono>();
        string jsondata = JsonUtility.ToJson(obj.GetComponent<TestMono>());
        Debug.Log(jsondata);

        //// ��ø�������� �׽�Ʈ
        GameObject obj2 = new GameObject();
        JsonUtility.FromJsonOverwrite(jsondata, obj2.AddComponent<TestMono>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
