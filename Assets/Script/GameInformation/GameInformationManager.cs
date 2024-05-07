using System;
using System.IO;
using UnityEngine;

public class GameInformationManager : GameControlSingleton<GameInformationManager> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;
    
    public delegate void GameDataSaveEventHandler();
    public static GameDataSaveEventHandler OnPlayerGameDataSave;
    public static GameDataSaveEventHandler OnWorldGameDataSave;

    
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
        
        OnPlayerGameDataSave += PlayerDataSave;
        OnWorldGameDataSave += WorldDataSave;
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
}