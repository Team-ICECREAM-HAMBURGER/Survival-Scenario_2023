using System.Collections.Generic;
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
    public static PlayerInfoUpdateHandler OnStatusEffectTextUpdateEvent;
    
    public delegate void PlayerInfoGaugeUpdateHandler(float value);
    public static PlayerInfoGaugeUpdateHandler OnStatusEffectGaugeUpdateEvent;
    
    public delegate void PlayerInfoGaugesUpdateHandler(Dictionary<statusType, float> values);
    public static PlayerInfoGaugesUpdateHandler OnStatusGaugesUpdateEvent;
    
    
    private void Init() {
        // TODO: Player Profile, Player Name Set; JSON
        
        OnDayCountUpdateEvent += DayCountUpdate;
        OnStatusGaugesUpdateEvent += StatusGaugesUpdate;
        
        OnStatusEffectTextUpdateEvent += StatusEffectTextUpdate;
        OnStatusEffectGaugeUpdateEvent += StatusEffectGaugeUpdate;
    }

    private void Awake() {
        Init();
    }

    private void DayCountUpdate(string value) {
        this.dayCount.text = $"{value}일 째 생존 중";
    }
    
    private void StatusEffectTextUpdate(string value) {
        this.statusEffectName.text = value;
    }

    private void StatusEffectGaugeUpdate(float value) {
        this.statusEffectGauge.value = value;
    }

    private void StatusGaugesUpdate(Dictionary<statusType, float> values) {
        int i = 0;
        
        foreach (var VARIABLE in values.Values) {
            this.statusGauges[i].value = VARIABLE;
            i += 1;
        }
    }
}