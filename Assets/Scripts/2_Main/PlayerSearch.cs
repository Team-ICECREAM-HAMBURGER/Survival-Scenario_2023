using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSearch : MonoBehaviour {
    [Header("Search")]
    [SerializeField] private Button okButton;
    [Space(10f)]
    [SerializeField] private GameObject searchingGameObject;
    
    private readonly Dictionary<eventType, IPlayerSearchEvent> _eventActions = 
        new Dictionary<eventType, IPlayerSearchEvent>() {
            { eventType.INJURED, new PlayerSearchEventInjured(98f) },
            { eventType.IN_DANGER, new PlayerSearchEventInDanger(0.5f) },
            { eventType.HUNTING, new PlayerSearchEventHunting(1f) },
            { eventType.FARMING, new PlayerSearchEventFarming(0.5f) }
        };
    
    
    public void Init() {
        Player.Instance.CanvasChange("Canvas Search");
        
        // Weight random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        foreach (IPlayerSearchEvent variable in this._eventActions.Values) {
            if (variable.Weight + weight >= randomPivot) {   // Selected!
                variable.Event();
                
                // Player Status Update
                Player.Instance.StatusUpdate(-20f, -10f, -10f, -10f);
                
                break;
            }
            
            weight += variable.Weight;
        }
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        this.searchingGameObject.SetActive(true);
        
        GameInfo.Instance.IsSearched = true;
    }

    private void SearchingResultOk() {
        // Return to Main Screen
        Player.Instance.CanvasChange("Canvas Main");
        Player.Instance.CanvasOn("Canvas Background");
        Player.Instance.CanvasOn("Canvas Info");
    }
}