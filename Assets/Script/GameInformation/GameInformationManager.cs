using System.IO;
using UnityEngine;



public class GameInformationManager : GameControlSingleton<GameInformationManager> {
    public GameInformationPlayerData gameInformationPlayerData;
    public GameInformationWorldData gameInformationWorldData;
    
    private delegate void GameDataEventHandler();
    private GameDataEventHandler OnGameDataSaveEvent;
    private GameDataEventHandler OnGameDataDeleteEvent;
    
    
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

    public void GameDataUpdate(GameControlType.GameSaveType type) {
        switch (type) {
            case GameControlType.GameSaveType.DATA_SAVE :
                this.OnGameDataSaveEvent.Invoke();
                break;
            case GameControlType.GameSaveType.DATA_DELETE :
                this.OnGameDataDeleteEvent.Invoke();
                break;
        }
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