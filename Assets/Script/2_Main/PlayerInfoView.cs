using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoView : MonoBehaviour {
    [SerializeField] private RawImage playerPicture;
    [SerializeField] private TMP_Text playerName;
    [Space(10f)]
    [SerializeField] private TMP_Text dayCounter;
    [Space(10f)]
    [SerializeField] private GameObject statusEffectIndicator;
    [Space(10f)] 
    [SerializeField] private Slider[] statusGauges;
    
    public delegate void PlayerStatusInfoHandler(Dictionary<StatusType, float> values);
    public static PlayerStatusInfoHandler OnPlayerStatusInfoUpdateEvent;

    public delegate void PlayerStatusEffectIndicatorHandler();
    public static PlayerStatusEffectIndicatorHandler OnPlayerStatusEffectIndicatorOnEvent;
    public static PlayerStatusEffectIndicatorHandler OnPlayerStatusEffectIndicatorOffEvent;
    public static PlayerStatusEffectIndicatorHandler OnPlayerStatusEffectIndicatorUpdateEvent;
    
    
    private void Init() {
        // TODO: Player Profile, Player Name Set; JSON
        OnPlayerStatusInfoUpdateEvent += StatusGaugesUpdate;

        OnPlayerStatusEffectIndicatorOnEvent += StatusEffectIndicatorOn;
        OnPlayerStatusEffectIndicatorOffEvent += StatusEffectIndicatorOff;
        OnPlayerStatusEffectIndicatorUpdateEvent += StatusEffectIndicatorUpdate;

        if (Player.Instance.CurrentStatusEffects.Count > 0) {
            StatusEffectIndicatorOn();
            
            return;
        }
        
        StatusEffectIndicatorOff();
    }

    private void Start() {
        Init();
    }

    private void StatusEffectIndicatorOn() {
        StatusEffectIndicatorUpdate();
        GamePanelControl.OnGamePanelOnEvent("Status Effect");
    }

    private void StatusEffectIndicatorUpdate() {
        var currentStatusEffects = Player.Instance.CurrentStatusEffects;
        
        // TODO: Tooltip 제작
    }
    
    private void StatusEffectIndicatorOff() {
        GamePanelControl.OnGamePanelOffEvent("Status Effect");
    }

    private void StatusGaugesUpdate(Dictionary<StatusType, float> values) {
        var i = 0;
        
        foreach (var variable in values.Values) {
            this.statusGauges[i].value = variable;
            i += 1;
        }
    }
}