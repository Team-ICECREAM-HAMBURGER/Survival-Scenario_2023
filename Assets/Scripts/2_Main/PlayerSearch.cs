using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSearch : MonoBehaviour {
    [SerializeField] private Button okButton;
    [Space(10f)]
    [SerializeField] private GameObject searchingScreen;
    
    private readonly Dictionary<eventType, IPlayerSearchEvent> eventActions = new Dictionary<eventType, IPlayerSearchEvent>() {
            { eventType.INJURED, new PlayerSearchEventInjured(0.5f) },
            { eventType.IN_DANGER, new PlayerSearchEventInDanger(0.5f) },
            { eventType.HUNTING, new PlayerSearchEventHunting(1f) },
            { eventType.FARMING, new PlayerSearchEventFarming(98f) }
        };

    public delegate void SearchEventHandler();
    public static SearchEventHandler OnSearchEvent;


    private void Init() {
        OnSearchEvent += Search;
    }

    private void Start() {
        Init();
    }
    
    private void Search() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Search");
        
        // Weight random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        // Event Select
        foreach (IPlayerSearchEvent variable in this.eventActions.Values) {
            if (variable.Weight + weight >= randomPivot) {
                variable.Event();
                
                break;
            }
            
            weight += variable.Weight;
        }
        
        // Player Status Update
        Player.Instance.StatusUpdate(-20f, -10f, -10f, -10f);
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        this.searchingScreen.SetActive(true);
    }

    private void SearchingResultOk() {
        // Return to Main Screen
        GameCanvasControl.OnCanvasChangeEvent("Canvas Main");
        GameCanvasControl.OnCanvasOnEvent("Canvas Background");
        GameCanvasControl.OnCanvasOnEvent("Canvas Info");
    }
}