using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInformationViewer : MonoBehaviour {
    [SerializeField] private GameObject playerInformationPanel;
    [SerializeField] private Image playerInformationPanelIndicator;

    [Space(10f)]

    [Header("Status Effect")]
    [SerializeField] private GameObject statusEffectContent;
    [field: SerializeField] private GameControlDictionary.StatusEffectText statusEffectText;
    
    [Space(10f)]

    [Header("Status")]
    [field: SerializeField] private GameControlDictionary.StatusGaugeSlider statusGaugeSlider;
    
    private float z;
    
    public static UnityEvent<GameControlType.Status, float> OnStatusGaugeUpdate;
    public static UnityEvent<GameControlType.StatusEffect, string> OnStatusEffectPanelUpdate;

    
    private void Init() {
        this.z = -90f;
        this.playerInformationPanel.SetActive(false);

        foreach (var VARIABLE in this.statusEffectText.Values) {
            VARIABLE.SetActive(false);
        }
        
        OnStatusGaugeUpdate = new();
        OnStatusGaugeUpdate.AddListener(StatusGaugeUpdate);

        OnStatusEffectPanelUpdate = new();
        OnStatusEffectPanelUpdate.AddListener(StatusEffectPanelUpdate);
    }

    private void Awake() {
        Init();
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
        this.playerInformationPanel.SetActive(!this.playerInformationPanel.activeSelf);
        this.playerInformationPanelIndicator.transform.rotation = Quaternion.Euler(0, 0, this.z);
    }
}