using System;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType {
    STAMINA,
    BODY_HEAT,
    HYDRATION,
    CALORIES
}

public enum EffectType {
    INJURE
}

public class Player : MonoBehaviour {
    public static Player instance;
    public List<Canvas> CanvasList;
    public Dictionary<StatusType, int> Status { get; private set; }
    public Dictionary<EffectType, bool> Effect { get; private set; }
    
    
    private void Init() {
        if (instance != null) {
            return;
        }
        
        instance = this;

        this.Status = new Dictionary<StatusType, int>();
        this.Effect = new Dictionary<EffectType, bool>();
        this.CanvasList = new List<Canvas>();
        
        foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Canvas")) {
            this.CanvasList.Add(VARIABLE.GetComponent<Canvas>());
        }
        
        // TODO: (Json -> Load) or (Create)
        this.Status.Add(StatusType.STAMINA, 100);
        this.Status.Add(StatusType.BODY_HEAT, 100);
        this.Status.Add(StatusType.CALORIES, 100);
        this.Status.Add(StatusType.HYDRATION, 100);
        this.Effect.Add(EffectType.INJURE, false);
    }

    private void Awake() {
        Init();
    }
}