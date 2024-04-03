using System.IO;
using UnityEngine;

public class GameInformation : GameContolSingleton<GameInformation> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;


    private void Init() {
        try {
            this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>();
        }
        catch (FileNotFoundException e) {
            // TODO: Save File Not Found.
            // PlayerInformation 객체 생성.
            // PlayerInformation Obj to Json
            // CreateJsonFile(PlayerInformation Json)
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