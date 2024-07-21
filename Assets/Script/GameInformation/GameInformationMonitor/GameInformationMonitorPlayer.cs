using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameInformationMonitorPlayer : MonoBehaviour {    // Presenter
    [Header("Status Effect Monitor")]
    [SerializeField] private GameObject statusEffectMonitorPanel;
    [SerializeField] private GameObject statusEffectMonitorContent;
    [SerializeField] private Image statusEffectMonitorToggleIndicator;

    [field: SerializeField] private GameControlDictionary.StatusEffectText statusEffectText;
    
    [Space(10f)]

    [Header("Status Gauge")]
    [field: SerializeField] private GameControlDictionary.StatusGaugeSlider statusGaugeSlider;
    
    private float z;
    
    public static UnityEvent<GameControlType.Status, float> OnStatusGaugeUpdate;
    public static UnityEvent<GameControlType.StatusEffect, string> OnStatusEffectPanelUpdate;

    
    public void Init() {
        this.z = -90f;
        this.statusEffectMonitorPanel.SetActive(false);

        foreach (var VARIABLE in this.statusEffectText.Values) {
            VARIABLE.SetActive(false);
        }
        
        OnStatusGaugeUpdate = new();
        OnStatusGaugeUpdate.AddListener(StatusGaugeUpdate); // 씬 전환에서도 리스너 정보를 유지

        OnStatusEffectPanelUpdate = new();
        OnStatusEffectPanelUpdate.AddListener(StatusEffectPanelUpdate); // 씬 전환에서도 리스너 정보를 유지
    }

    private void StatusGaugeUpdate(GameControlType.Status type, float value) {
        this.statusGaugeSlider[type].value = value;
    }
    
    private void StatusEffectPanelUpdate(GameControlType.StatusEffect type, string value) {
        if (Player.Instance.StatusEffect.ContainsKey(type)) {
            this.statusEffectText[type].GetComponent<TMP_Text>().text = value;
            this.statusEffectText[type].SetActive(true);
        }
        else {
            this.statusEffectText[type].SetActive(false);
        }
    }
    
    public void OnStatusEffectPanelActive() {
        this.z *= -1;
        this.statusEffectMonitorPanel.SetActive(!this.statusEffectMonitorPanel.activeSelf);
        this.statusEffectMonitorToggleIndicator.transform.rotation = Quaternion.Euler(0, 0, this.z);
    }
}