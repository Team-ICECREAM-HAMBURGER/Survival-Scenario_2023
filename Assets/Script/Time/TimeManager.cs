using UnityEngine;

public class TimeManager : GameControlSingleton<TimeManager> {
    private WorldInformation information;

    public int SpentTerm { get; private set; }
    private int currentTimeTerm;
    private int currentTimeDay;

    
    private void Init() {
        this.information = GameInformationManager.Instance.worldInformation;
        this.currentTimeTerm = this.information.timeTerm;
        this.currentTimeDay = this.information.timeDay;
    }

    private void Awake() {
    }
    
    private void Start() {
        Init();
    }
    
    public void WorldTimeUpdate(int value) {
        this.currentTimeTerm += value;
        this.SpentTerm = value;
        
        if (this.currentTimeTerm >= 500) {
            this.currentTimeDay += 1;
            this.currentTimeTerm -= 500;
        }
                    
        GameInformationManager.OnPlayerGameDataSave();
        GameInformationManager.OnWorldGameDataSave();
    }
}