using System.Collections.Generic;
using UnityEngine;

public enum dayNightType {
    DAY,
    NIGHT
}

public enum weatherType {
    SUNNY,
    RAIN,
    SNOW
}


public class GameInfo : MonoBehaviour {
    public static GameInfo Instance;
    
    public bool IsFireInstalled { get; set; }
    public bool IsShelterInstalled { get; set; }
    public bool IsRainGutterInstalled { get; set; }

    public int CurrentDay { get; private set; }
    public int CurrentTerm { get; private set; }
    public int CurrentFireTerm { get; private set; }
    
    public dayNightType CurrentDayNight { get; private set; }
    public IWeather CurrentWeather { get; private set; }

    public readonly Dictionary<weatherType, IWeather> Weather = new Dictionary<weatherType, IWeather>() {
        { weatherType.SUNNY, new WeatherSunny() },
        { weatherType.RAIN, new WeatherRain() },
        { weatherType.SNOW, new WeatherSnow() }
    };
    // TODO: DayNight Dictionary
    public delegate void TimeUpdateEventHandler(int value);
    public static TimeUpdateEventHandler OnTimeUpdateEvent;
    public static TimeUpdateEventHandler OnFireTimeUpdateEvent;

    
    private void Init() {
        if (Instance != null) {
            return;
        }

        Instance = this;
        
        // TODO: Json Save File Load
        this.IsFireInstalled = false;
        this.IsShelterInstalled = false;
        this.IsRainGutterInstalled = false;

        this.CurrentDay = 0;
        this.CurrentTerm = 0;
        this.CurrentFireTerm = 0;

        this.CurrentDayNight = dayNightType.DAY;
        this.CurrentWeather = this.Weather[weatherType.SUNNY];

        OnTimeUpdateEvent += TimeUpdate;
        OnFireTimeUpdateEvent += FireTimeUpdate;
    }

    private void Awake() {
        Init();
    }

    private void TimeUpdate(int value) {
        if (this.IsFireInstalled) {
            FireTimeUpdate(-value);
        }
        
        if (this.CurrentTerm >= 250) {
            this.CurrentDayNight = (this.CurrentDayNight == dayNightType.DAY) ? dayNightType.NIGHT : dayNightType.DAY;
            GameInfoView.OnDayNightUpdateEvent((this.CurrentDayNight == dayNightType.DAY) ? "낮" : "밤");
        }
        else if (this.CurrentTerm >= 500) {
            this.CurrentDay += 1;
            this.CurrentTerm = 0;
        }
        else {
            this.CurrentTerm += value;
        }
    }

    private void FireTimeUpdate(int value) {
        this.CurrentFireTerm += value;
        GameInfoView.OnFireTimeUpdateEvent($"모닥불 ({this.CurrentFireTerm}텀 남음)");

        if (this.CurrentFireTerm <= 0) {
            this.IsFireInstalled = false;
            PlayerFire.OnResetFireEvent();
        }
    }
}