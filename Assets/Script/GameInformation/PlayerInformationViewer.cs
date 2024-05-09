using UnityEngine;
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

    
    private void Init() {
        this.z = -90f;
        this.statusEffectPanel.SetActive(false);
    }

    private void Awake() {
        Init();
    }

    public void StatusEffectPanelUpdate() {
        // 내용 갱신
        this.z *= -1;
        this.statusEffectPanel.SetActive(!this.statusEffectPanel.activeSelf);
        this.statusEffectPanelIndicator.transform.rotation = Quaternion.Euler(0, 0, this.z);
    }
}