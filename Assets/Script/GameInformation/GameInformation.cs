public class GameInformation : GameContolSingleton<GameInformation> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;


    private void Init() {
        this.playerInformation = GameControlSaveLoad.Instance.LoadJsonFile<PlayerInformation>();
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