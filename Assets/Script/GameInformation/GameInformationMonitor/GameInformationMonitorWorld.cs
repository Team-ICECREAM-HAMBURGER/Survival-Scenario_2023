using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameInformationMonitorWorld : MonoBehaviour {
    [SerializeField] private TMP_Text currentLocation;
    [SerializeField] private TMP_Text currentWeather;
    [SerializeField] private TMP_Text currentDayNight;
    [SerializeField] private TMP_Text currentTimeDay;
    
    public static UnityEvent<int> OnCurrentTimeDayCounterUpdate;
    public static UnityEvent<string> OnCurrentLocationUpdate;
    public static UnityEvent<string> OnCurrentWeatherUpdate;
    public static UnityEvent OnCurrentDayNight;
    
    
    public void Init() {
        OnCurrentLocationUpdate = new();
        OnCurrentLocationUpdate.AddListener(CurrentLocationUpdate);
        
        OnCurrentWeatherUpdate = new();
        OnCurrentWeatherUpdate.AddListener(CurrentWeatherUpdate);
        
        OnCurrentDayNight = new();
        OnCurrentDayNight.AddListener(CurrentDayNight);
        
        OnCurrentTimeDayCounterUpdate = new();
        OnCurrentTimeDayCounterUpdate.AddListener(CurrentTimeDayCounterUpdate);   // 씬 전환에서도 리스너 정보를 유지
        
        OnCurrentTimeDayCounterUpdate.Invoke(World.Instance.TimeDay);
        OnCurrentWeatherUpdate.Invoke(World.Instance.Weather.Item2);
        OnCurrentLocationUpdate.Invoke(World.Instance.Location);    // TODO: (Enum, String)
    }
    
    private void CurrentTimeDayCounterUpdate(int value) {
        this.currentTimeDay.text = value + "일 째 생존 중...";
    }

    private void CurrentLocationUpdate(string value) {
        this.currentLocation.text = value;
    }

    private void CurrentWeatherUpdate(string value) {
        this.currentWeather.text = value;
    }

    private void CurrentDayNight() {
    }
}