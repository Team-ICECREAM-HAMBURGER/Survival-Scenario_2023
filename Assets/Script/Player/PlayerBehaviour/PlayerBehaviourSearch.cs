using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    [SerializeField] private GameObject searchCanvasObject;

    [Space(10f)]

    [Header("Require Status")]
    [SerializeField] private float requireStatusStamina;
    [SerializeField] private float requireStatusBodyHeat;
    [SerializeField] private float requireStatusHydration;
    [SerializeField] private float requireStatusCalories;
    
    [Space(10f)]

    [SerializeField] private GameObject searchResultPanel;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;

    [Space(10f)]
    
    [SerializeField] private GameObject searchLoadingPanel;
    [SerializeField] private TMP_Text searchLoadingTitle;

    private IGameRandomEvent[] searchRandomEvents;
    private float percentSum;
    private float percentLimit;
    private int spendTime;


    public void Init() {
        this.percentSum = 0;
        this.percentLimit = 0;
        this.spendTime = 5;
        this.searchRandomEvents = this.searchCanvasObject.GetComponents<IGameRandomEvent>();
    }

    public void Behaviour() {
        // Player Status Update
        Player.Instance.StatusUpdate(
            this.requireStatusStamina, 
            this.requireStatusBodyHeat, 
            this.requireStatusHydration, 
            this.requireStatusCalories);
        
        // Player Status Effects Invoke
        Player.Instance.StatusEffectInvoke(this.spendTime);
        
        // Random Event; Search
        RandomEventCall();
        
        World.Instance.WorldTimeUpdate(this.spendTime);
    }
    
    private void RandomEventCall() {
        this.percentSum = 0;
        this.percentLimit = Random.Range(0, 100);
        
        foreach (var VARIABLE in this.searchRandomEvents) {
            this.percentSum += VARIABLE.Percent;
            
            if (this.percentSum > this.percentLimit) {
                VARIABLE.Event();
                PanelUpdate(VARIABLE.EventResult());
                break;
            }
        }
    }
    
    private void PanelUpdate((string, string) value) {
        this.searchLoadingTitle.text = "주변을 탐색하는 중...";
        this.searchResultTitle.text = value.Item1;
        this.searchResultContent.text = value.Item2;
        
        this.searchLoadingPanel.SetActive(true);
        this.searchResultPanel.SetActive(true);
    }
}