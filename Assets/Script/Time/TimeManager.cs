using UnityEngine;

public class TimeManager : GameControlSingleton<TimeManager> {
    private WorldInformation information;

    private float currentTimeTerm;
    private float currentTimeDay;

    
    private void Init() {
        this.information = GameInformation.Instance.worldInformation;
        this.currentTimeTerm = this.information.timeTerm;
        this.currentTimeDay = this.information.timeDay;
    }

    private void Start() {
        Init();
    }
    
    public void WorldTermUpdate(int value) {
        this.currentTimeTerm += value;
        
        if (this.currentTimeTerm >= 2) {
            WorldTimeDayUpdate(1);
            this.currentTimeTerm -= 0;
        }
        
        StatusEffectManager.OnStatusEffectInvoke?.Invoke(value);
    }

    public void WorldTimeDayUpdate(int value) {
        this.currentTimeDay += value;
        GameInformation.OnGameDavaSave();
    }
}