using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoView : MonoBehaviour {
    [SerializeField] private RawImage playerProfile;
    [SerializeField] private TMP_Text playerName;
    [Space(10f)]
    [SerializeField] private TMP_Text dayCount;
    [Space(10f)]
    [SerializeField] private TMP_Text statusEffectName;
    [SerializeField] private Slider statusEffectGauge;
    [Space(10f)] 
    [SerializeField] private Slider[] statusGauges;

    public delegate void PlayerInfoUpdateHandler(string value);
    public static PlayerInfoUpdateHandler OnDayCountUpdateEvent;
    public static PlayerInfoUpdateHandler OnStatusEffectAddEvent;
    public static PlayerInfoUpdateHandler OnStatusEffectRemoveEvent;
    public static PlayerInfoUpdateHandler OnStatusEffectUpdateEvent;
    
    public delegate void PlayerInfoGaugeUpdateHandler();
    public static PlayerInfoGaugeUpdateHandler OnStatusEffectGaugeUpdateEvent;
    public static PlayerInfoGaugeUpdateHandler OnStatusGaugeUpdateEvent;
    
    
    private void Init() {
        // TODO: Player Profile, Player Name Set; JSON
        
        OnDayCountUpdateEvent += DayCountUpdate;
        
        OnStatusEffectAddEvent += StatusEffectAdd;
        OnStatusEffectRemoveEvent += StatusEffectRemove;
        OnStatusEffectUpdateEvent += StatusEffectUpdate;
        
        OnStatusEffectGaugeUpdateEvent += StatusEffectGaugeUpdate;
        OnStatusGaugeUpdateEvent += StatusGaugeUpdate;
    }

    private void Awake() {
        Init();
    }

    private void DayCountUpdate(string value) {
        this.dayCount.text = $"{value}일 째 생존 중";
    }

    private void StatusEffectAdd(string value) {
        this.statusEffectName.text = $"{value}";
    }

    private void StatusEffectRemove(string value) {
    }

    private void StatusEffectUpdate(string value) {
    }

    private void StatusEffectGaugeUpdate() {
    }

    private void StatusGaugeUpdate() {
    }
}