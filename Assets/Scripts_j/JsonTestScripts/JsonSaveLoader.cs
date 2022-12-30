using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class JsonSaveLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //// ������ ����
        //FileStream stream = new FileStream(Application.dataPath + "/GameData/test.json", FileMode.OpenOrCreate);
        //JsonExample jtest = new JsonExample();
        //string jsonData = JsonConvert.SerializeObject(jtest);
        //byte[] data = Encoding.UTF8.GetBytes(jsonData);
        //stream.Write(data, 0, data.Length);
        //stream.Close();

        // ������ �ε�
        FileStream stream = new FileStream(Application.dataPath + "/GameData/test.json", FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsondata = Encoding.UTF8.GetString(data);
        JsonExample jtest2 = JsonConvert.DeserializeObject<JsonExample>(jsondata);
        jtest2.print();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
