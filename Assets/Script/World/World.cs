using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class World : GameControlSingleton<World> {  // Model
    private const int DAYTERM = 500;
    
    [SerializeField] private WorldInformation worldInformation;
    
    private WorldInformationData informationData;
    private float weatherPercent;
    private int weatherTime;
    
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

    private (GameControlType.Weather, string) weather;
    public (GameControlType.Weather, string) Weather {
        get {
            return this.weather;
        }
        private set {
            this.weather = value;
            this.informationData.weather = value;
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

    private bool hasWater;
    public bool HasWater {
        get {
            return hasWater;
        }
        set {
            this.hasWater = value;
            this.informationData.hasWater = value;
        }
    }

    private bool isWinter;
    public bool IsWinter {
        get {
            return isWinter;
        }
        set {
            this.isWinter = value;
            this.informationData.isWinter = value;
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
            this.Weather = this.informationData.weather;
            this.Location = this.informationData.location;
            this.HasShelter = this.informationData.hasShelter;
            this.HasRainGutter = this.informationData.hasRainGutter;
            this.HasWater = this.informationData.hasWater;
            this.HasFire = this.informationData.hasFire;
            this.IsWinter = this.informationData.isWinter;
            this.FireTerm = this.informationData.fireTerm;

            this.weatherTime = 0;
            this.weatherPercent = 20f;
            
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
        
        if (this.TimeTerm >= DAYTERM) {
            this.TimeDay += 1;
            this.TimeTerm -= DAYTERM;
        }

        if (this.HasFire) {
            FireTimeUpdate(-value);
        }
        
        WorldInformation.OnCurrentTimeDayCounterUpdate.Invoke(World.Instance.TimeDay);
        WeatherUpdate(value);
    }

    private void WeatherUpdate(int value) {
        if (this.Weather.Item1 != GameControlType.Weather.CLEAR) {
            this.weatherTime -= value;
            
            if (this.weatherTime <= 0) {
                this.Weather = (GameControlType.Weather.CLEAR, "맑음");
            }
            
            return;
        }
        
        if (GameRandomEventManager.Instance.RandomEventPercentSelect(this.weatherPercent)) {
            this.Weather = !this.IsWinter ? 
                (GameControlType.Weather.RAIN, "비") : (GameControlType.Weather.SNOW, "눈보라");
            this.weatherTime = Random.Range(3, 6) * DAYTERM;
        }
        
        Debug.Log("날씨: " + this.Weather.Item2);
        WorldInformation.OnCurrentWeatherUpdate.Invoke(this.Weather.Item2);
    }
    
    private void FireTimeUpdate(int value) {
        if (this.Weather.Item1 != GameControlType.Weather.CLEAR) {
            value *= 2;
        }
        
        this.FireTerm += value;

        if (this.FireTerm <= 0) {
            this.HasFire = false;
            this.FireTerm = 0;
        }
    }
}