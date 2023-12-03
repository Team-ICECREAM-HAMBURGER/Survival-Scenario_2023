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
            { eventType.FARMING, new PlayerSearchEventFarming(98f) },
            { eventType.HUNTING, new playerSearchEventHunting(1f) },
            { eventType.INJURED, new PlayerSearchEventInjured(0.5f) },
            { eventType.IN_DANGER, new playerSearchEventInDanger(0.5f) }
        };
    
    
    public void Init() {
        Player.instance.CanvasChange("Canvas Search");
        
        // Weight random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        foreach (IPlayerSearchEvent variable in this._eventActions.Values) {
            if (variable.Weight + weight >= randomPivot) {   // Selected!
                variable.Event();
                
                // Player Status Update
                Player.instance.StatusUpdate(-20f, -10f, -10f, -10f);
                
                break;
            }
            
            weight += variable.Weight;
        }
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        this.searchingGameObject.SetActive(true);
        
        GameInfo.instance.IsSearched = true;
    }

    private void SearchingResultOk() {
        // Return to Main Screen
        Player.instance.CanvasChange("Canvas Main");
        Player.instance.CanvasOn("Canvas Background");
        Player.instance.CanvasOn("Canvas Info");
    }
}