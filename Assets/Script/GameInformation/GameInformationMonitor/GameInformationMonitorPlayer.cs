using UnityEngine;
using UnityEngine.UI;

public class GameInformationMonitorPlayer : MonoBehaviour {    // Presenter
    [Header("Status Effect Monitor")]
    [SerializeField] private GameObject statusEffectMonitorPanel;
    [SerializeField] private GameObject statusEffectMonitorContent;
    [SerializeField] private Image statusEffectMonitorToggleIndicator;
    
    private float z;

    
    public void Init() {
        this.z = -90f;
        this.statusEffectMonitorPanel.SetActive(false);
    }
    
    public void OnStatusEffectPanelActive() {
        this.z *= -1;
        this.statusEffectMonitorPanel.SetActive(!this.statusEffectMonitorPanel.activeSelf);
        this.statusEffectMonitorToggleIndicator.transform.rotation = Quaternion.Euler(0, 0, this.z);
    }
}