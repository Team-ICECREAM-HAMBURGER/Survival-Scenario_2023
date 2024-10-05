using TMPro;
using UnityEngine;

public class GameInformationMonitorManager : GameControlSingleton<GameInformationMonitorManager> {
    [field: SerializeField] public GameControlDictionary.StatusGaugeSlider StatusGaugeSliders { get; private set; }
    [field: SerializeField] public GameControlDictionary.StatusEffectText StatusEffectText { get; private set; }
    
    [Space(25f)]
    
    [Header("Game Information Monitor")] // TODO: Unity Event?
    [SerializeField] private GameInformationMonitorWorld gameInformationMonitorWorld;
    [SerializeField] private GameInformationMonitorPlayer gameInformationMonitorPlayer;

    
    public void Init() {
        foreach (var VARIABLE in this.StatusEffectText.Values) {
            VARIABLE.SetActive(false);
        }
        
        this.gameInformationMonitorWorld.Init();
        this.gameInformationMonitorPlayer.Init();
    }
    
    private void Awake() {}
    
    public void CurrentLocationUpdate(string value) {
        this.gameInformationMonitorWorld.CurrentLocationUpdate(value);
    }

    public void StatusGaugeUpdate(GameControlType.Status type, float value) {
        this.StatusGaugeSliders[type].value = value;
    }

    public void StatusEffectPanelUpdate(GameControlType.StatusEffect type, string value) {
        if (Player.Instance.StatusEffect.ContainsKey(type)) {
            this.StatusEffectText[type].GetComponent<TMP_Text>().text = value;
            this.StatusEffectText[type].SetActive(true);
        }
        else {
            this.StatusEffectText[type].SetActive(false);
        }
    }

    public void CurrentTimeDayCounterUpdate(int value) {
        this.gameInformationMonitorWorld.CurrentTimeDayCounterUpdate(value);
    }

    public void CurrentWeatherUpdate((GameControlType.Weather, string) value) {
        this.gameInformationMonitorWorld.CurrentWeatherUpdate(value);
    }
}