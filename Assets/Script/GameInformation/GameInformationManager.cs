using System;
using System.IO;
using UnityEngine;

public class GameInformationManager : GameControlSingleton<GameInformationManager> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;
    
    public delegate void GameDataEventHandler();
    public static GameDataEventHandler OnPlayerGameDataSaveEvent;
    public static GameDataEventHandler OnWorldGameDataSaveEvent;
    public static GameDataEventHandler OnGameDataDeleteEvent;
    
    
    private void Init() {
        // Save File Load/New
        try {
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>("Player");
            this.worldInformation = GameControlSaveLoad.Instance.LoadJsonFile<WorldInformation>("World");
        }
        catch (FileNotFoundException e) {
            Debug.Log("Save File Created.");

            var playerInit = GameControlSaveLoad.Instance.ObjectToJson(new PlayerInformation());
            var worldInit = GameControlSaveLoad.Instance.ObjectToJson(new WorldInformation());
            
            GameControlSaveLoad.Instance.CreateJsonFile(playerInit, "Player");
            GameControlSaveLoad.Instance.CreateJsonFile(worldInit, "World");
            
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>("Player");
            this.worldInformation = GameControlSaveLoad.Instance.LoadJsonFile<WorldInformation>("World");
        }
        
        OnPlayerGameDataSaveEvent += PlayerDataSave;
        OnWorldGameDataSaveEvent += WorldDataSave;
        OnGameDataDeleteEvent += GameDataDelete;
    }

    private void Start() {
        Init();
    }

    private void PlayerDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.playerInformation);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "Player");
    }

    private void WorldDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.worldInformation);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "World");
    }

    private void GameDataDelete() {
        GameControlSaveLoad.Instance.DeleteJsonFile();
        this.playerInformation = null;
        this.worldInformation = null;
    }
}