using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class World : GameControlSingleton<World> {  // Model
    private const int DAYTERM = 500;
    
    [SerializeField] private GameInformationMonitorWorld gameInformationMonitorWorld;
    
    private GameInformationWorldData data;
    private float weatherPercent;
    private int weatherTime;
    
    private int timeDay;
    public int TimeDay {
        get {
            return this.timeDay;
        }
        private set {
            this.timeDay = value;
            this.data.timeDay = value;
        }
    }

    private int timeTerm;
    public int TimeTerm {
        get {
            return this.timeTerm;
        }
        private set {
            this.timeTerm = value;
            this.data.timeTerm = value;
        }
    }

    private string location;
    public string Location {
        get {
            return this.location;
        }
        private set {
            this.location = value;
            this.data.location = value;
        }
    }

    private (GameControlType.Weather, string) weather;
    public (GameControlType.Weather, string) Weather {
        get {
            return this.weather;
        }
        private set {
            this.weather = value;
            this.data.weather = value;
        }
    }

    private bool hasShelter;
    public bool HasShelter {
        get {
            return hasShelter;
        }
        set {
            this.hasShelter = value;
            this.data.hasShelter = value;
        }
    }

    private bool hasRainGutter;
    public bool HasRainGutter {
        get {
            return hasRainGutter;
            
        }
        set {
            this.hasRainGutter = value;
            this.data.hasRainGutter = value;
        }
    }

    private bool hasFire;
    public bool HasFire {
        get {
            return hasFire;
        }
        set {
            this.hasFire = value;
            this.data.hasFire = value;
        }
    }

    private bool hasWater;
    public bool HasWater {
        get {
            return hasWater;
        }
        set {
            this.hasWater = value;
            this.data.hasWater = value;
        }
    }

    private bool isWinter;
    public bool IsWinter {
        get {
            return isWinter;
        }
        set {
            this.isWinter = value;
            this.data.isWinter = value;
        }
    }
    private int fireTerm;
    public int FireTerm {
        get {
            return this.fireTerm;
        }
        set {
            this.fireTerm = value;
            this.data.fireTerm = value;
        }
    }
    
    
    private void Init() {
        try {
            this.data = GameInformationManager.Instance.gameInformationWorldData;
            
            this.TimeDay = this.data.timeDay;
            this.TimeTerm = this.data.timeTerm;
            this.Weather = this.data.weather;
            this.Location = this.data.location;
            this.HasShelter = this.data.hasShelter;
            this.HasRainGutter = this.data.hasRainGutter;
            this.HasWater = this.data.hasWater;
            this.HasFire = this.data.hasFire;
            this.IsWinter = this.data.isWinter;
            this.FireTerm = this.data.fireTerm;

            this.weatherTime = 0;
            this.weatherPercent = 20f;
            
            // Presenter Init //
            this.gameInformationMonitorWorld.Init();
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
        
        GameInformationMonitorWorld.OnCurrentTimeDayCounterUpdate.Invoke(World.Instance.TimeDay);
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
        
        // GameRandomEventManager.Instance.RandomEventPercentSelect(this.weatherPercent)
        if (false) {
            this.Weather = !this.IsWinter ? 
                (GameControlType.Weather.RAIN, "비") : (GameControlType.Weather.SNOW, "눈보라");
            this.weatherTime = Random.Range(3, 6) * DAYTERM;
        }
        
        Debug.Log("날씨: " + this.Weather.Item2);
        GameInformationMonitorWorld.OnCurrentWeatherUpdate.Invoke(this.Weather.Item2);
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