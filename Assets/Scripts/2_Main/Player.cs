using System;
using System.Collections.Generic;
using System.Linq;
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
    //
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
        
        foreach (GameObject VARIABLE in GameObject.FindGameObjectsWithTag("Canvas")) {
            this.canvasList.Add(VARIABLE.GetComponent<Canvas>());
        }
        
        // TODO: (Json -> Load) or (Create)
        this.Status.Add(StatusType.STAMINA, 100);
        this.Status.Add(StatusType.BODY_HEAT, 100);
        this.Status.Add(StatusType.CALORIES, 100);
        this.Status.Add(StatusType.HYDRATION, 100);
        this.Effect.Add(EffectType.INJURE, false);
        this.Inventory.Add(ItemType.TORCH, 1);
        this.Inventory.Add(ItemType.FIRE_TOOL, 1);
        this.Inventory.Add(ItemType.KINDLING, 3);
        this.Inventory.Add(ItemType.WOOD, 1);
    }

    private void Awake() {
        Init();
    }
    
    public void CanvasChange(string canvasName) {
        foreach (Canvas VARIABLE in this.canvasList) {  // Canvas Change
            VARIABLE.enabled = false || VARIABLE.name == canvasName;
        }    
    }

    public void CanvasOn(string canvasName) {
        foreach (Canvas VARIABLE in this.canvasList.Where(VARIABLE => VARIABLE.name == canvasName)) {
            VARIABLE.enabled = true;
        }
    }

    public void CanvasOff(string canvasName) {
        foreach (Canvas VARIABLE in this.canvasList.Where(VARIABLE => VARIABLE.name == canvasName)) {
            VARIABLE.enabled = false;
        }
    }
}