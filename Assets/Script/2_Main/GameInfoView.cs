using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameInfoView : MonoBehaviour {
    [SerializeField] private TMP_Text location;
    [SerializeField] private TMP_Text weather;
    [SerializeField] private TMP_Text dayNight;
    [SerializeField] private TMP_Text fireTime;
    
    public delegate void GameInfoUpdateHandler(string value);
    public static GameInfoUpdateHandler OnLocationUpdateEvent;
    public static GameInfoUpdateHandler OnWeatherUpdateEvent;
    public static GameInfoUpdateHandler OnDayNightUpdateEvent;
    public static GameInfoUpdateHandler OnFireTimeUpdateEvent;

    
    private void Init() {
        OnLocationUpdateEvent += LocationUpdate;
        OnWeatherUpdateEvent += WeatherUpdate;
        OnDayNightUpdateEvent += DayNightUpdate;
        OnFireTimeUpdateEvent += FireTimeUpdate;
    }

    private void Awake() {
        Init();
    }

    private void FireTimeUpdate(string value) {
        this.fireTime.text = value;
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