using System;
using UnityEngine;
using UnityEngine.Serialization;

public class World : GameControlSingleton<World> {  // Model
    private WorldInformation information;

    private int timeDay;
    public int TimeDay {
        get {
            return this.timeDay;
        }
        private set {
            this.timeDay = value;
            this.information.timeDay = value;
        }
    }

    private int timeTerm;
    public int TimeTerm {
        get {
            return this.timeTerm;
        }
        private set {
            this.timeTerm = value;
            this.information.timeTerm = value;
        }
    }

    private bool hasShelter;
    public bool HasShelter {
        get {
            return hasShelter;
        }
        private set {
            this.hasShelter = value;
            this.information.hasShelter = value;
        }
    }

    private bool hasRainGutter;
    public bool HasRainGutter {
        get {
            return hasRainGutter;
            
        }
        private set {
            this.hasRainGutter = value;
            this.information.hasRainGutter = value;
        }
    }

    public int SpentTerm { get; private set; }
    public int CurrentTimeTerm { get; private set; }
    public int CurrentTimeDay { get; private set; }
    
    
    private void Init() {
        try {
            this.information = GameInformationManager.Instance.worldInformation;
            
            this.TimeDay = this.information.timeDay;
            this.TimeTerm = this.information.timeTerm;
            this.HasShelter = this.information.hasShelter;
            this.HasRainGutter = this.information.hasRainGutter;
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
        this.HasShelter = value;
    }

    public void RainGutterUpdate(bool value) {
        this.HasRainGutter = value;
    }
    
    public void WorldTimeUpdate(int value) {
        this.CurrentTimeTerm += value;
        this.SpentTerm = value;
        
        if (this.CurrentTimeTerm >= 500) {
            this.CurrentTimeDay += 1;
            this.CurrentTimeTerm -= 500;
        }
                    
        GameInformationManager.OnPlayerGameDataSaveEvent();
        GameInformationManager.OnWorldGameDataSaveEvent();
    }
}