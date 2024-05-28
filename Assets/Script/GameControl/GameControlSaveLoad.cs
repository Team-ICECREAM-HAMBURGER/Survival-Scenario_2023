using System;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class GameControlSaveLoad : GameControlSingleton<GameControlSaveLoad> {
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

    // Json -> File; New
    public void CreateJsonFile(string jsonData, string type) {
        var fileStream = new FileStream($"{this.filePath}/{this.fileName}_{type}.json", FileMode.Create);
        var data = Encoding.UTF8.GetBytes(jsonData);
        
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    
    // Json -> Obj
    public T LoadJsonFile<T>(string type) {
        if (!File.Exists($"{this.filePath}/{this.fileName}_{type}.json")) {
            throw new FileNotFoundException();
        }
        
        var fileStream = new FileStream($"{this.filePath}/{this.fileName}_{type}.json", FileMode.Open);
        var data = new byte[fileStream.Length];

        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        var jsonData = Encoding.UTF8.GetString(data);

        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    public void DeleteJsonFile() {
        foreach(var VARIABLE in Directory.GetFiles(this.filePath, $"{this.fileName}_*.json")) {
            File.Delete(VARIABLE);
        }
    }
}