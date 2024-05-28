using System;
using UnityEngine;

public class World : GameControlSingleton<World> {  // Model
    [SerializeField] private WorldInformation worldInformation;
    
    private WorldInformationData informationData;

    private int timeDay;
    public int TimeDay {
        get {
            return this.timeDay;
        }
        private set {
            this.timeDay = value;
            this.informationData.timeDay = value;
        }
    }

    private int timeTerm;
    public int TimeTerm {
        get {
            return this.timeTerm;
        }
        private set {
            this.timeTerm = value;
            this.informationData.timeTerm = value;
        }
    }

    private string location;

    public string Location {
        get {
            return this.location;
        }
        private set {
            this.location = value;
            this.informationData.location = value;
        }
    }

    private bool hasShelter;
    public bool HasShelter {
        get {
            return hasShelter;
        }
        set {
            this.hasShelter = value;
            this.informationData.hasShelter = value;
        }
    }

    private bool hasRainGutter;
    public bool HasRainGutter {
        get {
            return hasRainGutter;
            
        }
        set {
            this.hasRainGutter = value;
            this.informationData.hasRainGutter = value;
        }
    }
    
    
    private void Init() {
        try {
            this.informationData = GameInformationManager.Instance.worldInformationData;
            
            this.TimeDay = this.informationData.timeDay;
            this.TimeTerm = this.informationData.timeTerm;
            this.location = this.informationData.location;
            this.HasShelter = this.informationData.hasShelter;
            this.HasRainGutter = this.informationData.hasRainGutter;

            // Presenter Init //
            this.worldInformation.Init();

        }
        catch (NullReferenceException e) {
            Debug.Log("Game Over");
        }
    }
    
    private void Awake() {
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