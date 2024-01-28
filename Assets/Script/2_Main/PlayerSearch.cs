using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSearch : MonoBehaviour {
    [SerializeField] private GameObject searchLoadingScreen;
    
    private readonly Dictionary<EventType, IPlayerSearchEvent> eventActions = new Dictionary<EventType, IPlayerSearchEvent>() {
            { EventType.INJURED, new PlayerSearchEventInjured(0.2f) },
            { EventType.IN_DANGER, new PlayerSearchEventInDanger(0.2f) },
            { EventType.HUNTING, new PlayerSearchEventHunting(1f) },
            { EventType.FARMING, new PlayerSearchEventFarming(98f) }
        };

    public delegate void SearchEventHandler();
    public static SearchEventHandler OnSearchEvent;


    private void Init() {
        OnSearchEvent += Searching;
    }

    private void Start() {
        Init();
    }
    
    private void Searching() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Search");
        
        GameInfo.OnTimeUpdateEvent(1);
        this.searchLoadingScreen.SetActive(true);
        
        // Player Status Update
        Player.Instance.StatusUpdate(-20f, -10f, -10f, -10f);
        
        // Weight random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;
        
        // Event Select
        foreach (var variable in this.eventActions.Values) {
            if (variable.Weight + weight >= randomPivot) {
                variable.Event();
                
                break;
            }
            
            weight += variable.Weight;
        }
    }
}