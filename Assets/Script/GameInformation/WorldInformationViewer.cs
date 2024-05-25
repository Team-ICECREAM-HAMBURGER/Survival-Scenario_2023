using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WorldInformationViewer : MonoBehaviour {
    [SerializeField] private TMP_Text currentLocation;
    [SerializeField] private TMP_Text currentWeather;
    [SerializeField] private TMP_Text currentDayNight;
    [SerializeField] private TMP_Text currentTimeDay;
    
    public static UnityEvent<int> OnCurrentTimeDayUpdate;
    public static UnityEvent<string> OnCurrentLocationUpdate;
    public static UnityEvent OnCurrentWeatherUpdate;
    public static UnityEvent OnCurrentDayNight;
    
    
    private void Init() {
        OnCurrentLocationUpdate = new();
        OnCurrentLocationUpdate.AddListener(CurrentLocationUpdate);
        
        OnCurrentWeatherUpdate = new();
        OnCurrentWeatherUpdate.AddListener(CurrentWeatherUpdate);
        
        OnCurrentDayNight = new();
        OnCurrentDayNight.AddListener(CurrentDayNight);
        
        OnCurrentTimeDayUpdate = new();
        OnCurrentTimeDayUpdate.AddListener(CurrentTimeDayUpdate);   // 씬 전환에서도 리스너 정보를 유지
    }

    private void Awake() {
        Init();
    }
    
    private void CurrentTimeDayUpdate(int value) {
        this.currentTimeDay.text = value + "일 째 생존 중...";
    }

    private void CurrentLocationUpdate(string value) {
        this.currentLocation.text = value;
    }

    private void CurrentWeatherUpdate() {
    }

    private void CurrentDayNight() {
    }
}