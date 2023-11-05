using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DayNightType {
    Day,
    Night
}

public enum WeatherType {
    Sunny,
    Rain,
    Snow
}


public class GameInfo : MonoBehaviour {
    public static GameInfo Instance;

    public bool IsSearched { get; set; } = true;
    public bool IsShelterInstalled { get; set; } = true;
    public bool IsRainGutterInstalled { get; set; } = true;
    public bool IsFireInstalled { get; set; } = false;
    public int CurrentTerm { get; private set; }
    public int CurrentDay { get; private set; }
    public DayNightType CurrentDayNight { get; private set; }
    public WeatherType CurrentWeather { get; private set; }
    

    private void Init() {
        if (Instance != null) {
            return;
        }

        Instance = this;
        
        // TODO: (Json -> Load) or (Create)
        this.CurrentTerm = 0;
        this.CurrentDay = 0;
        this.CurrentDayNight = DayNightType.Night;
        this.CurrentWeather = WeatherType.Sunny;
    }

    private void Awake() {
        Init();
    }
}
