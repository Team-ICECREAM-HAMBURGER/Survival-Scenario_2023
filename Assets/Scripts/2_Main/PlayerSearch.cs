using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class playerSearch : MonoBehaviour {
    [Header("Search")]
    [SerializeField] private Button okButton;
    [Space(10f)]
    [SerializeField] private GameObject searchingGameObject;
    
    private readonly Dictionary<eventType, IPlayerSearchEvent> _eventActions =
        new Dictionary<eventType, IPlayerSearchEvent>() {
            { eventType.FARMING, new PlayerSearchEventFarming(1f) },
            { eventType.HUNTING, new playerSearchEventHunting(98f) },
            { eventType.INJURED, new playerSearchEventInjured(0.5f) },
            { eventType.IN_DANGER, new playerSearchEventInDanger(0.5f) }
        };
    
    
    public void Init() {
        player.instance.CanvasChange("Canvas Search");
        
        // Weight random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        foreach (IPlayerSearchEvent variable in this._eventActions.Values) {
            if (variable.Weight + weight >= randomPivot) {   // Selected!
                variable.Event();
                break;
            }
            
            weight += variable.Weight;
        }
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        this.searchingGameObject.SetActive(true);
    }

    private void SearchingResultOk() {
        // Return to Main Screen
        player.instance.CanvasChange("Canvas Main");
        player.instance.CanvasOn("Canvas Background");
        player.instance.CanvasOn("Canvas Info");
    }
}