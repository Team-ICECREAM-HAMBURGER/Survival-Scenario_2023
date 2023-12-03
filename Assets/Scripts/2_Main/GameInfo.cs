using System;
using System.Collections;
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
    public static GameInfo instance;

    public bool IsSearched { get; set; }
    public bool IsShelterInstalled { get; set; } = true;
    public bool IsRainGutterInstalled { get; set; } = true;
    public bool IsFireInstalled { get; set; } = false;
    public int CurrentTerm { get; private set; }
    public int CurrentDay { get; private set; }
    public dayNightType CurrentDayNight { get; private set; }
    public weatherType CurrentWeather { get; private set; }
    

    private void Init() {
        if (instance != null) {
            return;
        }

        instance = this;
        
        // TODO: (Json -> Load) or (Create)
        this.CurrentTerm = 0;
        this.CurrentDay = 0;
        this.CurrentDayNight = dayNightType.DAY;
        this.CurrentWeather = weatherType.SUNNY;
    }

    private void Awake() {
        Init();
    }
}
