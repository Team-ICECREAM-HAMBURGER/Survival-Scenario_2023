using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public enum StatusType {
    STAMINA,
    BODY_HEAT,
    HYDRATION,
    CALORIES
}

public enum EffectType {
    INJURE
}

public enum ItemType {
    HAND_AXE,
    TORCH,
    BOTTLE_WATER,
    BOTTLE_EMPTY,
    HUNTING_TOOL,
    FIRE_TOOL,
    KINDLING,
    MEDICINE,
    ROASTED_MEAT,
    ROPE,
    
    WATER,
    FIRE,
    RAW_MEAT,
    PLASTIC_BAG,
    MISCELLANEOUS,
    WOOD,
    CAN,
    HERBS,
    FLINT,
    CLOTH,
    STONE,
    MRE
}

public class Player : MonoBehaviour {
    public static Player Instance;
    
    public List<Canvas> canvasList;
    public Dictionary<StatusType, int> Status { get; private set; }
    public Dictionary<EffectType, bool> Effect { get; private set; }
    public Dictionary<ItemType, int> Inventory { get; private set; }
    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;

        this.Status = new Dictionary<StatusType, int>();
        this.Effect = new Dictionary<EffectType, bool>();
        this.Inventory = new Dictionary<ItemType, int>();
        
        this.canvasList = new List<Canvas>();
        
        foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Canvas")) {
            this.canvasList.Add(VARIABLE.GetComponent<Canvas>());
        }
        
        // TODO: (Json -> Load) or (Create)
        this.Status.Add(StatusType.STAMINA, 100);
        this.Status.Add(StatusType.BODY_HEAT, 100);
        this.Status.Add(StatusType.CALORIES, 100);
        this.Status.Add(StatusType.HYDRATION, 100);
        this.Effect.Add(EffectType.INJURE, false);
        this.Inventory.Add(ItemType.TORCH, 1);
    }

    private void Awake() {
        Init();
    }
}