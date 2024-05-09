using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInformationViewer : MonoBehaviour {
    [Header("Status Effect")]
    [SerializeField] private GameObject statusEffectPanel;
    [SerializeField] private Image statusEffectPanelIndicator;

    [Space(10f)]

    [Header("Status")]
    [SerializeField] private Slider statusStaminaGauge;
    [SerializeField] private Slider statusBodyHeatGauge;
    [SerializeField] private Slider statusHydrationGauge;
    [SerializeField] private Slider statusCaloriesGauge;
    
    private float z;

    public static UnityEvent OnStatusGaugeUpdate;
    
    
    private void Init() {
        
        this.z = -90f;
        this.statusEffectPanel.SetActive(false);
        
        // Player Status Gauge Init();
        
        
        
        
    }

    private void Awake() {
        Init();
    }

    public void OnInvoke() {
        ViewerUpdate();
        
        this.z *= -1;
        this.statusEffectPanel.SetActive(!this.statusEffectPanel.activeSelf);
        this.statusEffectPanelIndicator.transform.rotation = Quaternion.Euler(0, 0, this.z);
    }

    private void ViewerUpdate() {
        // StatusEffect Update
        // Status Gauge Update
        // TODO: PlayerStatus에서 처리하는 Gauge 갱신 작업을 여기서 수행한다.
        // TODO: 현재 플레이어에게 적용되어 있는 상태 이상 효과 관련 정보를 받아와 여기서 출력한다.
                // - 출력해야 하는 데이터
                // 상태 이상 효과의 이름
                // 상태 이상 효과 지속 시간 (조건 타입일 경우, 발동 조건을 출력)
        // 
    }
}