using System.IO;
using UnityEngine;

public class GameInformation : GameControlSingleton<GameInformation> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;


    private void Init() {
        try {
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>();
        }
        catch (FileNotFoundException e) {
            Debug.Log("Player Information Save File Created.");
            
            GameControlSaveLoad.Instance.CreateJsonFile(
                GameControlSaveLoad.Instance.ObjectToJson(new PlayerInformation()));
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>();
        }
    }

    private void Awake() {
        Init();
    }

    // TODO: Generic
    public void PlayerDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.playerInformation);
        
        GameControlSaveLoad.Instance.CreateJsonFile(saveData);
    }
}