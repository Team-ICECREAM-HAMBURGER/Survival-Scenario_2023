using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSearch : MonoBehaviour {
    [SerializeField] private GameObject searchLoadingScreen;
    
    private readonly Dictionary<eventType, IPlayerSearchEvent> eventActions = new Dictionary<eventType, IPlayerSearchEvent>() {
            { eventType.INJURED, new PlayerSearchEventInjured(0.2f) },
            { eventType.IN_DANGER, new PlayerSearchEventInDanger(0.2f) },
            { eventType.HUNTING, new PlayerSearchEventHunting(1f) },
            { eventType.FARMING, new PlayerSearchEventFarming(98f) }
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
        foreach (IPlayerSearchEvent variable in this.eventActions.Values) {
            if (variable.Weight + weight >= randomPivot) {
                variable.Event();
                
                break;
            }
            
            weight += variable.Weight;
        }
    }
}