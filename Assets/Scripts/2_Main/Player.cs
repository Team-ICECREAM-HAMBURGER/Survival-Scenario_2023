using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum statusType {
    STAMINA,
    BODY_HEAT,
    HYDRATION,
    CALORIES
}

public enum effectType {
    INJURE
}

public enum itemType {
    HAND_AXE,
    TORCH,
    EMPTY_BOTTLE,
    FILLED_BOTTLE,
    HUNTING_TOOL,
    FIRE_TOOL,
    KINDLING,
    MEDICINE,
    MRE,
    ROPE,
    RAW_MEAT,
    COOKED_MEAT,
    PLASTIC_BAG,
    MISCELLANEOUS,
    WOOD,
    CAN,
    HERBS,
    FLINT,
    CLOTH,
    STONE,
}

public class player : MonoBehaviour {
    public static player instance;
    
    public List<Canvas> canvasList;
    
    public playerMain PlayerMain { get; private set; }
    public playerMove PlayerMove { get; private set; }
    public playerSearch PlayerSearch { get; private set; }
    
    // TODO: Readonly, Initialize
    public Dictionary<statusType, int> Status { get; private set; }
    public Dictionary<effectType, bool> Effect { get; private set; }
    
    public readonly Dictionary<itemType, Item> inventory = new Dictionary<itemType, Item>() {
        { itemType.HERBS, new ItemHerbs() },
        { itemType.ROPE, new ItemRope() },
        { itemType.CAN, new ItemCan() },
        { itemType.CLOTH, new ItemCloth() },
        { itemType.PLASTIC_BAG, new ItemPlasticBag() },
        { itemType.MISCELLANEOUS, new ItemMiscellaneous() },
        { itemType.STONE, new ItemStone() },
        { itemType.WOOD, new ItemWood() },
        //
        { itemType.MRE, new ItemMre() },
        { itemType.TORCH, new ItemTorch() },
        { itemType.RAW_MEAT, new ItemMeatRaw() },
        { itemType.COOKED_MEAT, new ItemMeatCooked() },
        { itemType.FIRE_TOOL, new ItemFireTool() },
        { itemType.KINDLING, new ItemKindling() },
        { itemType.MEDICINE, new ItemMedicine() },
        { itemType.EMPTY_BOTTLE, new ItemBottleEmpty() },
        { itemType.FILLED_BOTTLE, new ItemBottleFilled() },
        { itemType.HUNTING_TOOL, new ItemHuntingTool() }
    };

    
    private void Init() {
        if (instance != null) {
            return;
        }
        
        instance = this;

        this.PlayerMain = this.gameObject.GetComponent<playerMain>();
        this.PlayerMove = this.gameObject.GetComponent<playerMove>();
        this.PlayerSearch = this.gameObject.GetComponent<playerSearch>();

        this.Status = new Dictionary<statusType, int>();
        this.Effect = new Dictionary<effectType, bool>();
        
        this.canvasList = new List<Canvas>();
        
        foreach (GameObject variable in GameObject.FindGameObjectsWithTag("Canvas")) {
            this.canvasList.Add(variable.GetComponent<Canvas>());
        }
        
        // TODO: JSON -> Status Value Load
        this.Status.Add(statusType.STAMINA, 100);
        this.Status.Add(statusType.BODY_HEAT, 100);
        this.Status.Add(statusType.CALORIES, 100);
        this.Status.Add(statusType.HYDRATION, 100);
        this.Effect.Add(effectType.INJURE, false);
        
        // TODO: JSON -> Inventory Value Load
    }

    private void Awake() {
        Init();
    }
    
    public void CanvasChange(string canvasName) {
        foreach (Canvas variable in this.canvasList) {  // Canvas Change
            variable.enabled = false || variable.name == canvasName;
        }    
    }

    public void CanvasOn(string canvasName) {
        foreach (Canvas variable in this.canvasList.Where(variable => variable.name == canvasName)) {
            variable.enabled = true;
        }
    }

    public void CanvasOff(string canvasName) {
        foreach (Canvas variable in this.canvasList.Where(variable => variable.name == canvasName)) {
            variable.enabled = false;
        }
    }

    public void StatusUpdate(int value) {
        foreach (var variable in this.Status) {
            Debug.Log(variable.Value);
        }
        
        for (int i = 0; i < this.Status.Count; i++) {
            this.Status[(statusType)i] += value;
        }

        foreach (var variable in this.Status) {
            Debug.Log(variable.Value);
        }
    }

    public void StatusUpdate(int stamina, int bodyHeat, int hydration, int calories) {
        // TODO: Each Status value update.
    }
}