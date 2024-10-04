using TMPro;
using UnityEngine;

public class GameInformationMonitorWorld : MonoBehaviour {
    [SerializeField] private TMP_Text currentLocation;
    [SerializeField] private TMP_Text currentWeather;
    [SerializeField] private TMP_Text currentDayNight;
    [SerializeField] private TMP_Text currentTimeDay;
    
    
    public void Init() {
        CurrentLocationUpdate(World.Instance.Location);
        CurrentTimeDayCounterUpdate(World.Instance.TimeDay);
        CurrentWeatherUpdate(World.Instance.Weather);
        CurrentDayNight();
    }
    
    public void CurrentTimeDayCounterUpdate(int value) {
        this.currentTimeDay.text = value + "일 째 생존 중...";
    }

    public void CurrentLocationUpdate(string value) {
        this.currentLocation.text = value;
    }

    public void CurrentWeatherUpdate((GameControlType.Weather, string) value) {
        this.currentWeather.text = value.Item2;
    }

    public void CurrentDayNight() {
    }
}