using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoView : MonoBehaviour {
    [SerializeField] private TMP_Text location;
    [SerializeField] private TMP_Text weather;
    [SerializeField] private TMP_Text dayNight;
    
    public delegate void GameInfoUpdateHandler(string value);
    public static GameInfoUpdateHandler OnLocationUpdateEvent;
    public static GameInfoUpdateHandler OnWeatherUpdateEvent;
    public static GameInfoUpdateHandler OnDayNightUpdateEvent;

    
    private void Init() {
        OnLocationUpdateEvent += LocationUpdate;
        OnWeatherUpdateEvent += WeatherUpdate;
        OnDayNightUpdateEvent += DayNightUpdate;
    }

    private void Awake() {
        Init();
    }

    private void LocationUpdate(string value) {
        this.location.text = value;
    }
    
    private void WeatherUpdate(string value) {
        this.weather.text = value;
    }
    
    private void DayNightUpdate(string value) {
        this.dayNight.text = value;
    }
}