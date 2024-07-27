using TMPro;
using UnityEngine;

public class PlayerBehaviourSearch : PlayerBehaviour {   // Presenter
    [Space(25f)]

    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject searchResultPanel;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;

    [Space(25f)]
    
    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject searchLoadingPanel;
    [SerializeField] private TMP_Text searchLoadingTitle;

    private int searchSpendTime;
    
    private float searchRandomEventWeight;
    

    public override void Init() {
        this.OnPlayerStatusUpdate = new();
        this.searchSpendTime = 5;
    }

    public override void Behaviour() {
        // Player Status Update
        this.OnPlayerStatusUpdate.Invoke();
        
        // Player Status Effects Invoke
        PlayerBehaviourManager.Instance.StatusEffectInvoke();
        
        // Random Event; Search
        PlayerBehaviourManager.Instance.RandomEventWeightSelect();
        
        // Word Info. Update
        PlayerBehaviourManager.Instance.WorldTimeUpdate(this.searchSpendTime);
        
        // Game Data Update
        PlayerBehaviourManager.Instance.GameDataSaveInvoke();
        
        //PanelUpdate();
        
        
        // PanelUpdate(this.randomEvent.EventResult());
    }
    
    private void PanelUpdate((string, string) value) {
        this.searchLoadingTitle.text = "주변을 탐색하는 중...";
        this.searchResultTitle.text = value.Item1;
        this.searchResultContent.text = value.Item2;
        
        this.searchLoadingPanel.SetActive(true);
        this.searchResultPanel.SetActive(true);
    }
}