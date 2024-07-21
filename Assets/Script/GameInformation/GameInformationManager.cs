using System;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class GameInformationManager : GameControlSingleton<GameInformationManager> {
    [FormerlySerializedAs("playerInformationData")] public GameInformationPlayerData gameInformationPlayerData;
    [FormerlySerializedAs("worldInformationData")] public GameInformationWorldData gameInformationWorldData;
    
    public delegate void GameDataEventHandler();
    public static GameDataEventHandler OnGameDataSaveEvent;
    public static GameDataEventHandler OnGameDataDeleteEvent;
    
    
    private void Init() {
        // Save File Load/New
        try {
            this.gameInformationPlayerData = GameControlSaveLoad.Instance.LoadJsonFile<GameInformationPlayerData>("Player");
            this.gameInformationWorldData = GameControlSaveLoad.Instance.LoadJsonFile<GameInformationWorldData>("World");
        }
        catch (FileNotFoundException e) {
            Debug.Log("Save File Created.");

            var playerInit = GameControlSaveLoad.Instance.ObjectToJson(new GameInformationPlayerData());
            var worldInit = GameControlSaveLoad.Instance.ObjectToJson(new GameInformationWorldData());
            
            GameControlSaveLoad.Instance.CreateJsonFile(playerInit, "Player");
            GameControlSaveLoad.Instance.CreateJsonFile(worldInit, "World");
            
            this.gameInformationPlayerData = GameControlSaveLoad.Instance.LoadJsonFile<GameInformationPlayerData>("Player");
            this.gameInformationWorldData = GameControlSaveLoad.Instance.LoadJsonFile<GameInformationWorldData>("World");
        }

        OnGameDataSaveEvent += PlayerDataSave;
        OnGameDataSaveEvent += WorldDataSave;
        OnGameDataDeleteEvent += GameDataDelete;
    }

    private void Awake() {
        Init();
    }
    
    private void PlayerDataSave() {
        Debug.Log("Player Data Saved");
        
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.gameInformationPlayerData);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "Player");
    }

    private void WorldDataSave() {
        Debug.Log("World Data Saved");

        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.gameInformationWorldData);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "World");
    }

    private void GameDataDelete() {
        GameControlSaveLoad.Instance.DeleteJsonFile();
        this.gameInformationPlayerData = null;
        this.gameInformationWorldData = null;
    }
}