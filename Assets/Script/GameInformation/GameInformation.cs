using System.Collections.Generic;

public class GameInformation : GameContolSingleton<GameInformation> {
    public PlayerInformation playerInformation;
    public WorldInformation worldInformation;
    
    
    // Player Information
    public class PlayerInformation {
        public string name;
        public Dictionary<GameTypeItem, IItem> inventory = new();
        public Dictionary<GameTypeStatus, IPlayerStatus> status = new();
        public Dictionary<GameTypeStatusEffect, IPlayerStatusEffect> statusEffect = new();
    }
    
    // World Information
    public class WorldInformation {
        public int timeTerm;
        public int timeDay;
        public IWeather weather;
        public ILocation location;
    }

    private void Init() { 
        // TODO: 세이브 파일 로드
        this.playerInformation = new();
        this.worldInformation = new();
        
        //this.playerInformation = GameControlSaveLoad.Instance.LoadSaveFile<PlayerInformation>();
        //this.worldInformation = GameControlSaveLoad.Instance.LoadSaveFile<WorldInformation>();
    }

    private void Awake() {
        Init();
    }
}