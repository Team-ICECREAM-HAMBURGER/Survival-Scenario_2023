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
    
    private readonly Dictionary<EventType, IPlayerEvent> eventActions =
        new Dictionary<EventType, IPlayerEvent>() {
            { EventType.FARMING, new PlayerEventFarming(90f) },
            { EventType.HUNTING, new PlayerEventHunting(5f) },
            { EventType.INJURED, new PlayerEventInjured(2.5f) },
            { EventType.IN_DANGER, new PlayerEventInDanger(2.5f) }
        };
    
    
    public void Init() {
        Player.Instance.CanvasChange("Canvas Search");
        
        // 가중치 랜덤 뽑기
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        foreach (IPlayerEvent VARIABLE in this.eventActions.Values) {
            if (VARIABLE.Weight + weight >= randomPivot) {   // Selected!
                VARIABLE.Event();
                break;
            }
            
            weight += VARIABLE.Weight;
        }
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        searchingGameObject.SetActive(true);
    }

    private void SearchingResultOk() {
    }
}