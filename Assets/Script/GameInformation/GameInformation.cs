using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameInformation : GameControlSingleton<GameInformation> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;
    
    public delegate void GameDavaSaveEventHandler();
    public static GameDavaSaveEventHandler OnGameDavaSave;
    
    
    private void Init() {
        // Save File Load/New
        try {
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>();
        }
        catch (FileNotFoundException e) {
            Debug.Log("Player Information Save File Created.");
            
            GameControlSaveLoad.Instance.CreateJsonFile(
                GameControlSaveLoad.Instance.ObjectToJson(new PlayerInformation()));
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>();
        }
        
        OnGameDavaSave += PlayerDataSave;
        OnGameDavaSave += WorldDataSave;
    }

    private void Start() {
        Init();
    }
    
    private void PlayerDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.playerInformation);
        
        Debug.Log(saveData);
        GameControlSaveLoad.Instance.CreateJsonFile(saveData);
    }

    private void WorldDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.worldInformation);
        
        Debug.Log(saveData);
        GameControlSaveLoad.Instance.CreateJsonFile(saveData);
    }
}