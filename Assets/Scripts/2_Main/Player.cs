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
    BOTTLE,
    HUNTING_TOOL,
    FIRE_TOOL,
    KINDLING,
    MEDICINE,
    MRE,
    //
    ROPE,
    MEAT,
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
    
    // TODO: Readonly
    public Dictionary<statusType, int> Status { get; private set; }
    public Dictionary<effectType, bool> Effect { get; private set; }
    
    public readonly Dictionary<itemType, IItem> inventory = new Dictionary<itemType, IItem>() {
        { itemType.CAN, new itemCan() },
        { itemType.MRE, new itemMre() },
        { itemType.ROPE, new itemRope() },
        { itemType.WOOD, new ItemWood() },
        { itemType.CLOTH, new itemCloth() },
        { itemType.FLINT, new itemFlint() },
        { itemType.HERBS, new itemHerbs() },
        { itemType.STONE, new itemStone() },
        { itemType.TORCH, new ItemTorch() },
        { itemType.MEAT, new itemMeat() },
        { itemType.FIRE_TOOL, new ItemFireTool() },
        { itemType.KINDLING, new ItemKindling() },
        { itemType.MEDICINE, new itemMedicine() },
        { itemType.PLASTIC_BAG, new itemPlasticBag() },
        { itemType.BOTTLE, new ItemBottle() },
        { itemType.HUNTING_TOOL, new itemHuntingTool() },
        { itemType.MISCELLANEOUS, new itemMiscellaneous() }
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
        
        // TODO: (Json -> Load) or (Create)
        this.Status.Add(statusType.STAMINA, 100);
        this.Status.Add(statusType.BODY_HEAT, 100);
        this.Status.Add(statusType.CALORIES, 100);
        this.Status.Add(statusType.HYDRATION, 100);
        this.Effect.Add(effectType.INJURE, false);
        
        //this.Inventory.Add(ItemType.TORCH, new ItemFireTool());
        // TODO: JSON -> Value Edit
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