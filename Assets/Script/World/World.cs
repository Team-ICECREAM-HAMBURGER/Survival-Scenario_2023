using System;
using UnityEngine;
using UnityEngine.Serialization;

public class World : GameControlSingleton<World> {  // Model
    private WorldInformation information;
    public int TimeDay { get; private set; }
    public int TimeTerm { get; private set; }
    public int SpentTerm { get; private set; }
    public bool IsShelterSet { get; private set; }
    public bool IsRainGutterSet { get; private set; }
    
    private int currentTimeTerm;
    private int currentTimeDay;
    
    
    private void Init() {
        try {
            this.information = GameInformationManager.Instance.worldInformation;
            
            this.TimeDay = this.information.timeDay;
            this.TimeTerm = this.information.timeTerm;
            this.IsShelterSet = this.information.isShelterSet;
            this.IsRainGutterSet = this.information.isRainGutterSet;
        }
        catch (NullReferenceException e) {
            Debug.Log("Game Over");
        }
    }
    
    private void Awake() {
    }
    
    private void Start() {  
        Init();
    }

    public void ShelterUpdate(bool value) {
        this.IsShelterSet = value;
    }

    public void RainGutterUpdate(bool value) {
        this.IsRainGutterSet = value;
    }
    
    public void WorldTimeUpdate(int value) {
        this.currentTimeTerm += value;
        this.SpentTerm = value;
        
        if (this.currentTimeTerm >= 500) {
            this.currentTimeDay += 1;
            this.currentTimeTerm -= 500;
        }
                    
        GameInformationManager.OnPlayerGameDataSaveEvent();
        GameInformationManager.OnWorldGameDataSaveEvent();
    }
}