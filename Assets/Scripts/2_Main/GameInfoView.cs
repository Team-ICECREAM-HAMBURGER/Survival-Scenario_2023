using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public enum dayNightType {
    DAY,
    NIGHT
}

public enum weatherType {
    SUNNY,
    RAIN,
    SNOW
}


public class GameInfoView : MonoBehaviour {
    public static GameInfoView Instance;

    [SerializeField] private TMP_Text currentStatusEffect;

    public bool IsSearched { get; set; }
    public bool IsShelterInstalled { get; set; } = true;
    public bool IsRainGutterInstalled { get; set; } = true;
    public bool IsFireInstalled { get; set; } = false;
    public int CurrentTerm { get; private set; } = 0;
    public int CurrentDay { get; private set; } = 0;
    public dayNightType CurrentDayNight { get; private set; } = dayNightType.DAY;
    public weatherType CurrentWeather { get; private set; } = weatherType.SUNNY;


    private void Init() {
        if (Instance != null) {
            return;
        }

        Instance = this;
    }

    private void Awake() {
        Init();
    }

    public void StatusEffectUpdate(string value) {
        this.currentStatusEffect.text = "현재 적용된 상태 이상: " + value;
    }
}