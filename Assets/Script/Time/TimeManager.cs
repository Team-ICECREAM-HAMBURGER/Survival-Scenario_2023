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
    
    public void WorldTimeUpdate(int value) {
        this.currentTimeTerm += value;
        
        if (this.currentTimeTerm >= 500) {
            this.currentTimeDay += 1;
            this.currentTimeTerm -= 500;
        }
        
        StatusEffectManager.OnStatusEffectInvoke?.Invoke(value);
    }
}