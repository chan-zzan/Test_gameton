using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class GameDataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        // 데이터 저장
        FileStream stream = new FileStream(Application.dataPath + "/Data_Game/GameDatas/SAVE_DATA.json", FileMode.OpenOrCreate);
        
        if (stream == null)
        {
            Debug.Log(" 데이터 저장 실패 ! ");
        }
        else
        {
            WaveData wave = new WaveData();
            // 직렬화된 정보 저장
            string waveData = JsonConvert.SerializeObject(wave);
            byte[] data = Encoding.UTF8.GetBytes(waveData);
            stream.Write(data, 0, data.Length);
            stream.Close();
        }
    }

    public WaveData LoadData(string file_path)
    {
        // 데이터 로드
        FileStream stream = new FileStream(Application.dataPath + file_path, FileMode.Open);
        
        if (stream == null)
        {
            Debug.Log(" 데이터 로드 실패 ! ");
            return null;
        }
        else
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            stream.Close();
            string waveData = Encoding.UTF8.GetString(data);
            WaveData wave = JsonConvert.DeserializeObject<WaveData>(waveData);
            return wave;
        }
    }

}
