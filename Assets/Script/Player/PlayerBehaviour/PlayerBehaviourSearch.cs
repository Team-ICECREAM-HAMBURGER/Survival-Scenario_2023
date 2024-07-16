using TMPro;
using UnityEngine;

public class PlayerBehaviourSearch : PlayerBehaviour {   // Presenter
    [SerializeField] private GameObject searchRandomObject;

    [Space(10f)]

    [Header("Require Status")]
    [field: SerializeField] private GameControlDictionary.RequireStatus requireStatuses;
    
    [Space(10f)]

    [SerializeField] private GameObject searchResultPanel;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;

    [Space(10f)]
    
    [SerializeField] private GameObject searchLoadingPanel;
    [SerializeField] private TMP_Text searchLoadingTitle;

    private GameRandomEvent randomEvent;
    private int spendTime;
    

    public override void Init() {
        this.spendTime = 5;
    }

    public override void Behaviour() {
        // Player Status Update
        foreach (var VARIABLE in this.requireStatuses) {
            PlayerStatusManager.Instance.Statuses[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
        
        // Player Status Effects Invoke
        PlayerStatusEffectManager.Instance.StatusEffectInvoke();
        
        // Random Event; Search
        this.randomEvent = GameRandomEventManager.Instance.RandomEventPercentSelect();
        this.randomEvent.Event();
        
        // Word Info. Update
        World.Instance.TimeUpdate(this.spendTime);
        
        // Game Data Update
        GameInformationManager.OnGameDataSaveEvent();
        
        PanelUpdate(this.randomEvent.EventResult());
    }
    
    private void PanelUpdate((string, string) value) {
        this.searchLoadingTitle.text = "주변을 탐색하는 중...";
        this.searchResultTitle.text = value.Item1;
        this.searchResultContent.text = value.Item2;
        
        this.searchLoadingPanel.SetActive(true);
        this.searchResultPanel.SetActive(true);
    }
}