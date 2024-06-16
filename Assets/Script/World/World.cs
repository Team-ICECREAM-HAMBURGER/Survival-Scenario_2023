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

    private bool hasFire;
    public bool HasFire {
        get {
            return hasFire;
        }
        set {
            this.hasFire = value;
            this.informationData.hasFire = value;
        }
    }

    private int fireTerm;
    public int FireTerm {
        get {
            return this.fireTerm;
        }
        set {
            this.fireTerm = value;
            this.informationData.fireTerm = value;
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
            this.HasFire = this.informationData.hasFire;
            this.FireTerm = this.informationData.fireTerm;
            
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
    
    public void TimeUpdate(int value) {
        this.TimeTerm += value;
        
        if (this.TimeTerm >= 500) {
            this.TimeDay += 1;
            this.TimeTerm -= 500;
        }

        if (this.HasFire) {
            FireTimeUpdate(-value);
        }
        
        GameInformationManager.OnPlayerGameDataSaveEvent();
        GameInformationManager.OnWorldGameDataSaveEvent();
    }

    public void WorldDataSave() {
        GameInformationManager.OnPlayerGameDataSaveEvent();
        GameInformationManager.OnWorldGameDataSaveEvent();
    }
    
    public void FireTimeUpdate(int value) {
        this.FireTerm += value;

        if (this.FireTerm <= 0) {
            this.HasFire = false;
            this.FireTerm = 0;
        }
    }
}