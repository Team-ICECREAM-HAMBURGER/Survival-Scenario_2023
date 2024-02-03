using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInfoView : MonoBehaviour {
    [SerializeField] private RawImage playerPicture;
    [SerializeField] private TMP_Text playerName;
    [Space(10f)]
    [SerializeField] private TMP_Text dayCount;
    [Space(10f)]
    [SerializeField] private TMP_Text statusEffectName;
    [SerializeField] private Slider statusEffectGauge;
    [Space(10f)] 
    [SerializeField] private Slider[] statusGauges;

    public delegate void PlayerStatusInfoUpdateHandler(Dictionary<StatusType, float> values);
    public static PlayerStatusInfoUpdateHandler OnPlayerStatusInfoUpdateEvent;

    public delegate void PlayerStatusEffectInfoUpdateHandler(IPlayerStatusEffect value);
    public static PlayerStatusEffectInfoUpdateHandler OnPlayerStatusEffectInfoInitEvent;
    public static PlayerStatusEffectInfoUpdateHandler OnPlayerStatusEffectInfoUpdateEvent;
    public static PlayerStatusEffectInfoUpdateHandler OnPlayerStatusEffectInfoOffEvent;

    
    private void Init() {
        // TODO: Player Profile, Player Name Set; JSON
        OnPlayerStatusInfoUpdateEvent += StatusGaugesUpdate;
        OnPlayerStatusEffectInfoInitEvent += StatusEffectGaugeInit;
        OnPlayerStatusEffectInfoUpdateEvent += StatusEffectGaugeUpdate;
    }

    private void Awake() {
        Init();
    }

    private void StatusEffectGaugeInit(IPlayerStatusEffect value) {
        this.statusEffectName.text = value.StatusEffectName;
        this.statusEffectGauge.maxValue = value.DurationTerm;
        
        GamePanelControl.OnGamePanelOnEvent("Status Effect Gauge");
    }
    
    private void StatusEffectGaugeUpdate(IPlayerStatusEffect value) {
        this.statusEffectGauge.value = value.DurationTerm;
    }

    private void StatusGaugesUpdate(Dictionary<StatusType, float> values) {
        var i = 0;
        
        foreach (var variable in values.Values) {
            this.statusGauges[i].value = variable;
            i += 1;
        }
    }
}