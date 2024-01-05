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
    
    public bool IsFireInstalled { get; private set; }
    public bool IsShelterInstalled { get; private set; }
    public bool IsRainGutterInstalled { get; private set; }

    public int CurrentDay { get; private set; }
    public int CurrentTerm { get; private set; }
    
    public dayNightType CurrentDayNight { get; private set; }
    public weatherType CurrentWeather { get; private set; }

    public delegate void TimeUpdateEventHandler(int value);
    public static TimeUpdateEventHandler OnTimeUpdateEvent;

    
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

        this.CurrentDayNight = dayNightType.DAY;
        this.CurrentWeather = weatherType.SUNNY;

        OnTimeUpdateEvent += TimeUpdate;
    }

    private void Awake() {
        Init();
    }

    private void TimeUpdate(int value) {
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
}