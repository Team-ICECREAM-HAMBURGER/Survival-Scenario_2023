using TMPro;
using UnityEngine;

public class GameInfoView : MonoBehaviour {
    [SerializeField] private TMP_Text currentStatusEffect;
    [SerializeField] private TMP_Text currentDay;
    [SerializeField] private TMP_Text currentTerm;
    [SerializeField] private TMP_Text currentDayNight;
    [SerializeField] private TMP_Text currentWeather;
    
    public delegate void StatusEffectUIActiveHandler(string value);
    public static StatusEffectUIActiveHandler OnStatusEffectUIUpdateEvent;

    public delegate void StatusEffectUIDeActivateHandler();
    public static StatusEffectUIDeActivateHandler OnStatusEffectUIResetEvent;

    public delegate void CurrentTimeUIUpdateHandler(int term, int day);
    public static CurrentTimeUIUpdateHandler OnCurrentTimeUIUpdateEvent;
    
    
    private void Init() {
        OnStatusEffectUIUpdateEvent += StatusEffectUIUpdate;
        OnStatusEffectUIResetEvent += StatusEffectUIReset;
        OnCurrentTimeUIUpdateEvent += CurrentTimeUIUpdate;
    }

    private void Awake() {
        Init();
    }
    
    private void StatusEffectUIUpdate(string value) {
        this.currentStatusEffect.text = "현재 적용된 상태 이상: " + value;
    }

    private void StatusEffectUIReset() {
        this.currentStatusEffect.text = "현재 적용된 상태 이상: " + "없음";
    }
    
    // TODO: CurrentDay, Term, DayNight, Weather
    private void CurrentTimeUIUpdate(int term, int day) {
        this.currentDay.text = $"{day} 일";
        this.currentTerm.text = $"{term} 텀";
    }
}