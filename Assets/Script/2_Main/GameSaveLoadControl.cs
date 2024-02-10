using System;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class GameSaveLoadControl : MonoBehaviour {
    public static GameSaveLoadControl Instance;

    public string fileName = DateTime.Now.ToString("yyyy-MM-dd");
    public string filePath = Application.persistentDataPath;

    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;
    }

    private void Awake() {
        Init();
    }
    
    public string DataSave(object obj) {
        return JsonConvert.SerializeObject(obj);
    }

    public T DataLoad<T>(string data) {
        return JsonConvert.DeserializeObject<T>(data);
    }

    public void CreateSaveFile(string saveData) {
        FileStream fileStream = new FileStream($"{this.filePath}/{this.fileName}.json", FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(saveData);
        
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public T LoadSaveFile<T>() {
        FileStream fileStream = new FileStream($"{this.filePath}/{this.fileName}.json", FileMode.Open);
        byte[] data = new byte[fileStream.Length];

        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        
        string loadData = Encoding.UTF8.GetString(data);

        return JsonConvert.DeserializeObject<T>(loadData);
    }

    public bool SaveFileCheck() {
        FileInfo fileInfo = new FileInfo($"{this.filePath}/{this.fileName}.json");
        
        return fileInfo.Exists;
    }
}