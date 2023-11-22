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
    
    private readonly Dictionary<EventType, IPlayerSearchEvent> eventActions =
        new Dictionary<EventType, IPlayerSearchEvent>() {
            { EventType.FARMING, new PlayerSearchEventFarming(90f) },
            { EventType.HUNTING, new PlayerSearchEventHunting(5f) },
            { EventType.INJURED, new PlayerSearchEventInjured(2.5f) },
            { EventType.IN_DANGER, new PlayerSearchEventInDanger(2.5f) }
        };
    
    
    public void Init() {
        Player.Instance.CanvasChange("Canvas Search");
        
        // Weight random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        foreach (IPlayerSearchEvent VARIABLE in this.eventActions.Values) {
            if (VARIABLE.Weight + weight >= randomPivot) {   // Selected!
                VARIABLE.Event();
                break;
            }
            
            weight += VARIABLE.Weight;
        }
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        this.searchingGameObject.SetActive(true);
    }

    private void SearchingResultOk() {
        // Return to Main Screen
        Player.Instance.CanvasChange("Canvas Main");
        Player.Instance.CanvasOn("Canvas Background");
        Player.Instance.CanvasOn("Canvas Info");
    }
}