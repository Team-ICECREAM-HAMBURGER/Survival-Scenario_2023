using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
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

    private List<IGameRandomEvent> searchRandomEvents;
    private IGameRandomEvent randomEvent;
    private int spendTime;
    

    public void Init() {
        this.spendTime = 5;
        this.searchRandomEvents = new List<IGameRandomEvent>(
            this.searchRandomObject.GetComponents<IGameRandomEvent>()
                .ToList()
                .OrderBy(i => i.Percent)
            );
    }

    public void Behaviour() {
        // Player Status Update
        Player.Instance.StatusUpdate(this.requireStatuses, -1);
        
        // Player Status Effects Invoke
        Player.Instance.StatusEffectInvoke(this.spendTime);
        
        // Random Event; Search
        this.randomEvent = GameEventManager.Instance.RandomEventPercentSelect(this.searchRandomEvents);
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