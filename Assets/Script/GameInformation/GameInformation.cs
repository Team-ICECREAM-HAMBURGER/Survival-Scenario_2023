using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameInformation : GameControlSingleton<GameInformation> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;
    
    
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
    }

    private void Awake() {
        Init();
    }

    // TODO: Generic
    public void PlayerDataSave() {
        var saveData = GameControlSaveLoad.Instance.ObjectToJson(this.playerInformation);
        Debug.Log(saveData);
        GameControlSaveLoad.Instance.CreateJsonFile(saveData);
    }

    public void WorldTimeTermUpdate(int term) {
        this.worldInformation.timeTerm += term;
    }

    public void WorldTimeDayUpdate(int value) {
        this.worldInformation.timeDay += value;
    }
}