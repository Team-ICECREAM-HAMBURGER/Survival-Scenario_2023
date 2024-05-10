using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[System.Serializable] public class StatusGauges : SerializableDictionary<GameControlType.Status, Slider> { } 
public class PlayerInformationViewer : MonoBehaviour {
    [Header("Status Effect")]
    [SerializeField] private GameObject statusEffectPanel;
    [SerializeField] private Image statusEffectPanelIndicator;

    [Space(10f)]

    [Header("Status")]
    [field: SerializeField] private StatusGauges statusGauges;
    
    private float z;
    public static UnityEvent<GameControlType.Status, float> OnStatusGaugeUpdate;
        
    
    private void Init() {
        this.z = -90f;
        this.statusEffectPanel.SetActive(false);
        
        OnStatusGaugeUpdate = new();
        OnStatusGaugeUpdate.AddListener(StatusGaugeUpdate);
    }

    private void Awake() {
        Init();
    }

    private void StatusGaugeUpdate(GameControlType.Status type, float value) {
        this.statusGauges[type].value = value;
    }
    
    public void StatusEffectPanelUpdate() {
        // TODO: 패널 내용 갱신
        this.z *= -1;
        this.statusEffectPanel.SetActive(!this.statusEffectPanel.activeSelf);
        this.statusEffectPanelIndicator.transform.rotation = Quaternion.Euler(0, 0, this.z);
    }
}