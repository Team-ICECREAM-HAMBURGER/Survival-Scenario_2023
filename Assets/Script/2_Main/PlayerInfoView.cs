using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoView : MonoBehaviour {
    [Header("Player Profile")]
    [SerializeField] private RawImage playerPicture;
    [SerializeField] private TMP_Text playerName;
    
    [Space(10f)]
    
    [Header("Day Information")]
    [SerializeField] private TMP_Text dayCounter;
    
    [Space(10f)]
    
    [Header("Player Status Effect")]
    [SerializeField] private Button statusEffectButton;
    [SerializeField] private GameObject statusEffectArrow;
    [SerializeField] private GameObject statusEffectTooltip;
    [SerializeField] private TMP_Text statusEffectContent;
    private bool isToolTipOn;
    private StringBuilder resultText;
    
    
    [Space(10f)]
    
    [SerializeField] private List<Slider> statusGauges;
    
    public delegate void PlayerStatusInfoHandler(StatusType statusType, float value);
    public static PlayerStatusInfoHandler OnPlayerStatusInfoUpdateEvent;

    public delegate void PlayerStatusEffectIndicatorHandler();
    public static PlayerStatusEffectIndicatorHandler OnPlayerStatusEffectIndicatorOnEvent;
    public static PlayerStatusEffectIndicatorHandler OnPlayerStatusEffectIndicatorOffEvent;
    public static PlayerStatusEffectIndicatorHandler OnPlayerStatusEffectIndicatorUpdateEvent;
    
    
    private void Init() {
        // TODO: Player Profile, Player Name Set/Load; JSON
        OnPlayerStatusInfoUpdateEvent += StatusGaugesUpdate;

        OnPlayerStatusEffectIndicatorOnEvent += StatusEffectIndicatorOn;
        OnPlayerStatusEffectIndicatorOffEvent += StatusEffectIndicatorOff;
        OnPlayerStatusEffectIndicatorUpdateEvent += StatusEffectIndicatorUpdate;
        
        this.statusEffectButton.onClick.AddListener(TooltipControl);

        this.resultText = new StringBuilder();
        
        this.isToolTipOn = false;
        this.statusEffectTooltip.SetActive(false);
        this.statusEffectArrow.transform.rotation = Quaternion.Euler(0, 0, -90);
        
        // TODO: Player.Init() -> PlayerInfoView.Init() ; delegate Event Call
        if (Player.Instance.CurrentStatusEffects.Count > 0) {
            StatusEffectIndicatorOn();
            
            return;
        }
        
        StatusEffectIndicatorOff();
    }

    private void Start() {
        Init();
    }

    private void TooltipControl() {
        if (this.isToolTipOn) {   // True
            this.isToolTipOn = false;
            this.statusEffectTooltip.SetActive(false);
            this.statusEffectArrow.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else {  // False
            this.isToolTipOn = true;
            this.statusEffectTooltip.SetActive(true);
            this.statusEffectArrow.transform.rotation = Quaternion.Euler(0, 0, 90);
            
            foreach (var effect in Player.Instance.CurrentStatusEffects) {
                if (effect.StatusEffectType == StatusEffectType.INJURED) {
                    var day = ((PlayerStatusEffectInjured)effect).DurationTerm / 500;
                    var term = 500 * day;
                    
                    this.resultText.Append($"- {effect.StatusEffectName} ({day}일 {term}텀 남음)\n");
                }
                else {
                    //this.resultText.Append($"- {effect.StatusEffectName} ({}이 {}% 이하)");
                }
            }
        }
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

    private void StatusGaugesUpdate(StatusType statusType, float value) {
        this.statusGauges[statusType].value = value;
    }
}