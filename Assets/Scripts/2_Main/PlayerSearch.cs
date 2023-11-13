using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum EventType {
    FARMING,
    HUNTING,
    INJURED,
    IN_DANGER
}

public class PlayerSearch : MonoBehaviour {
    [Header("Search")] 
    [SerializeField] private Button okButton;
    [Space(10f)] 
    [SerializeField] private GameObject searchingGameObject;

    private delegate void SearchEventAction();

    private readonly Dictionary<EventType, SearchEventAction> eventActions =
        new Dictionary<EventType, SearchEventAction>() {
            { EventType.FARMING, FarmingEvent },
            { EventType.HUNTING, HuntingEvent },
            { EventType.INJURED, InjuredEvent },
            { EventType.IN_DANGER, InDangerEvent }
        };
    
    public void Init() {
        Player.Instance.CanvasChange("Canvas Search");
        
        // TODO : 가중치 랜덤 뽑기 적용 -> https://rito15.github.io/posts/unity-toy-weighted-random-picker/
        EventType randomEvent = (EventType)Random.Range(0, System.Enum.GetValues(typeof(EventType)).Length);
        this.eventActions[randomEvent].Invoke();
        
        this.okButton.onClick.AddListener(SearchingResultOk);
        
        searchingGameObject.SetActive(true);
    }

    private void SearchingResultOk() {
        
    }
    
    private static void FarmingEvent() {
        Debug.Log("FarmingEvent");
    }

    private static void HuntingEvent() {
        Debug.Log("HuntingEvent");
    }

    private static void InjuredEvent() {
        Debug.Log("InjuredEvent");
    }
    
    private static void InDangerEvent() {
        Debug.Log("InDangerEvent");
    }
}