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

    private string location;

    public string Location {
        get {
            return this.location;
        }
        private set {
            this.location = value;
            this.information.location = value;
        }
    }

    private bool hasShelter;
    public bool HasShelter {
        get {
            return hasShelter;
        }
        set {
            this.hasShelter = value;
            this.information.hasShelter = value;
        }
    }

    private bool hasRainGutter;
    public bool HasRainGutter {
        get {
            return hasRainGutter;
            
        }
        set {
            this.hasRainGutter = value;
            this.information.hasRainGutter = value;
        }
    }
    
    
    private void Init() {
        try {
            this.information = GameInformationManager.Instance.worldInformation;
            
            this.TimeDay = this.information.timeDay;
            this.TimeTerm = this.information.timeTerm;
            this.location = this.information.location;
            this.HasShelter = this.information.hasShelter;
            this.HasRainGutter = this.information.hasRainGutter;

            WorldInformationViewer.OnCurrentTimeDayUpdate.Invoke(this.TimeDay);
            WorldInformationViewer.OnCurrentLocationUpdate.Invoke(this.Location);
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
    
    public void WorldTimeUpdate(int value) {
        this.TimeTerm += value;
        
        if (this.TimeTerm >= 500) {
            this.TimeDay += 1;
            this.TimeTerm -= 500;
        }
        
        GameInformationManager.OnPlayerGameDataSaveEvent();
        GameInformationManager.OnWorldGameDataSaveEvent();
    }
}