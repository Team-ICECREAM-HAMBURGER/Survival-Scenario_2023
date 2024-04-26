using System.IO;
using UnityEngine;

public class GameInformation : GameControlSingleton<GameInformation> {
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

    private void Awake() {  // TODO: Start()로 바꾸면 게임 데이터 저장이 안된다... 나한테 왜 그래... ;ㅅ;)
        Init();
    }
    
    private void PlayerDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.playerInformation);
        
        Debug.Log(saveData);
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "Player");
    }

    private void WorldDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.worldInformation);
        
        Debug.Log(saveData);
        GameControlSaveLoad.Instance.CreateJsonFile(saveData, "World");
    }
}