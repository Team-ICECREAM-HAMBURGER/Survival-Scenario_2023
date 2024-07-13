using System;
using System.IO;
using UnityEngine;

public class GameInformationManager : GameControlSingleton<GameInformationManager> {
    public PlayerInformationData playerInformationData;
    public WorldInformationData worldInformationData;
    
    public delegate void GameDataEventHandler();
    public static GameDataEventHandler OnGameDataSaveEvent;
    public static GameDataEventHandler OnGameDataDeleteEvent;
    
    
    private void Init() {
        // Save File Load/New
        try {
            this.playerInformationData = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformationData>("Player");
            this.worldInformationData = GameControlSaveLoad.Instance.LoadJsonFile<WorldInformationData>("World");
        }
        catch (FileNotFoundException e) {
            Debug.Log("Save File Created.");

            var playerInit = GameControlSaveLoad.Instance.ObjectToJson(new PlayerInformationData());
            var worldInit = GameControlSaveLoad.Instance.ObjectToJson(new WorldInformationData());
            
            GameControlSaveLoad.Instance.CreateJsonFile(playerInit, "Player");
            GameControlSaveLoad.Instance.CreateJsonFile(worldInit, "World");
            
            this.playerInformationData = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformationData>("Player");
            this.worldInformationData = GameControlSaveLoad.Instance.LoadJsonFile<WorldInformationData>("World");
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
        
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.playerInformationData);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "Player");
    }

    private void WorldDataSave() {
        Debug.Log("World Data Saved");

        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.worldInformationData);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "World");
    }

    private void GameDataDelete() {
        GameControlSaveLoad.Instance.DeleteJsonFile();
        this.playerInformationData = null;
        this.worldInformationData = null;
    }
}