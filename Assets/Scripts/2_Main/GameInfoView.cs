using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameInfoView : MonoBehaviour {
    [SerializeField] private TMP_Text statusEffect;
    [SerializeField] private TMP_Text day;
    [SerializeField] private TMP_Text term;
    [SerializeField] private TMP_Text dayNight;
    [SerializeField] private TMP_Text weather;
    [Space(10f)]
    [SerializeField] private Slider[] playerStatusGauges;
    
    public delegate void StatusEffectUIActiveHandler(string value);
    public static StatusEffectUIActiveHandler OnStatusEffectUIUpdateEvent;

    public delegate void StatusEffectUIDeActivateHandler();
    public static StatusEffectUIDeActivateHandler OnStatusEffectUIResetEvent;

    public delegate void TimeUIUpdateHandler(int term, int day);
    public static TimeUIUpdateHandler OnTimeUIUpdateEvent;

    public delegate void DayNightUIUpdateHandler(string value);
    public static DayNightUIUpdateHandler OnDayNightUIUpdateEvent;

    public delegate void WeatherUIUpdateHandler();
    public static WeatherUIUpdateHandler OnWeatherUIUpdateEvent;

    public delegate void PlayerStatusUIUpdateHandler();
    public static PlayerStatusUIUpdateHandler OnPlayerStatusUIUpdateEvent;
    
    
    private void Init() {
        OnStatusEffectUIUpdateEvent += StatusEffectUIUpdate;
        OnStatusEffectUIResetEvent += StatusEffectUIReset;
        OnTimeUIUpdateEvent += TimeUIUpdate;
        OnDayNightUIUpdateEvent += DayNightUIUpdate;
        OnWeatherUIUpdateEvent += WeatherUIUpdate;
        OnPlayerStatusUIUpdateEvent += PlayerStatusUIUpdate;
    }

    private void Awake() {
        Init();
    }
    
    private void StatusEffectUIUpdate(string value) {
        this.statusEffect.text = $"현재 적용된 상태 이상: {value}";
    }

    private void StatusEffectUIReset() {
        this.statusEffect.text = "현재 적용된 상태 이상: 없음";
    }
    
    private void TimeUIUpdate(int term, int day) {
        this.day.text = $"{day} 일";
        this.term.text = $"{term} 텀";
    }

    private void DayNightUIUpdate(string value) {
        this.dayNight.text = value;
    }

    private void WeatherUIUpdate() {
    }

    private void PlayerStatusUIUpdate() {
        foreach (var VARIABLE in Player.Instance.Status) {
            this.playerStatusGauges[(int)VARIABLE.Key].value = VARIABLE.Value;
        }
    }
}