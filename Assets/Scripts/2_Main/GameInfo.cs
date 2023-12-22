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
    }

    private void Awake() {
        Init();
    }
}