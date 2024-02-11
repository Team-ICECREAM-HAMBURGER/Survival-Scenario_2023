using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {
    [SerializeField] private GameObject searchLoadingScreen;
    
    private readonly Dictionary<EventType, IPlayerSearchEvent> eventActions = new Dictionary<EventType, IPlayerSearchEvent>() {
            { EventType.INJURED, new PlayerSearchEventInjured(98f) },
            { EventType.IN_DANGER, new PlayerSearchEventInDanger(0.2f) },
            { EventType.HUNTING, new PlayerSearchEventHunting(1f) },
            { EventType.FARMING, new PlayerSearchEventFarming(0.2f) }
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
        
        GameInfoControl.OnTimeUpdateEvent(1);
        this.searchLoadingScreen.SetActive(true);
        
        // Player Status Update
        //Player.Instance.StatusUpdate(-20f, -10f, -10f, -10f);
        
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

    public void Behaviour() {
        throw new System.NotImplementedException();
    }

    public bool CanBehaviour() {
        throw new System.NotImplementedException();
    }
}