using System;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class GameControlSaveLoad : GameContolSingleton<GameControlSaveLoad> {
    private string fileName;
    private string filePath;


    private void Init() {
        this.fileName = DateTime.Now.ToString("yyyy-MM-dd");
        this.filePath = Application.persistentDataPath;
    }

    private void Awake() {
        Init();
    }

    // Obj -> Json
    public string ObjectToJson(object obj) {
        return JsonConvert.SerializeObject(obj);
    }

    // Json -> Obj
    public T JsonToObject<T>(string jsonData) {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    // Json -> File
    public void CreateJsonFile(string jsonData) {
        FileStream fileStream = new FileStream($"{this.filePath}/{this.fileName}.json", FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    
    // Json -> Obj
    public T LoadJsonFile<T>() {
        FileStream fileStream = new FileStream($"{this.filePath}/{this.fileName}.json", FileMode.Open);
        byte[] data = new byte[fileStream.Length];

        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        var jsonData = Encoding.UTF8.GetString(data);

        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}