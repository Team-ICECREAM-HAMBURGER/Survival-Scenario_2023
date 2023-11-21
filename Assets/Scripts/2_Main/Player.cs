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

public class Player : MonoBehaviour {
    public static Player Instance;
    
    public List<Canvas> canvasList;
    public Dictionary<StatusType, int> Status { get; private set; }
    public Dictionary<EffectType, bool> Effect { get; private set; }
    public Dictionary<ItemType, IGameItem> Inventory { get; private set; } = new Dictionary<ItemType, IGameItem>() {
        { ItemType.CAN, new GameItemCan() },
        { ItemType.MRE, new GameItemMre() },
        { ItemType.ROPE, new GameItemRope() },
        { ItemType.WOOD, new GameItemWood() },
        { ItemType.CLOTH, new GameItemCloth() },
        { ItemType.FLINT, new GameItemFlint() },
        { ItemType.HERBS, new GameItemHerbs() },
        { ItemType.STONE, new GameItemStone() },
        { ItemType.TORCH, new GameItemTorch() },
        { ItemType.MEAT, new GameItemMeat() },
        { ItemType.FIRE_TOOL, new GameItemFireTool() },
        { ItemType.KINDLING, new GameItemKindling() },
        { ItemType.MEDICINE, new GameItemMedicine() },
        { ItemType.PLASTIC_BAG, new GameItemPlasticBag() },
        { ItemType.BOTTLE, new GameItemBottle() },
        { ItemType.HUNTING_TOOL, new GameItemHuntingTool() },
        { ItemType.MISCELLANEOUS, new GameItemMiscellaneous() }
    }; // TODO: Init (All of Items!!)

    public PlayerMain PlayerMain { get; private set; }
    public PlayerMove PlayerMove { get; private set; }
    public PlayerSearch PlayerSearch { get; private set; }
    
    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;

        this.PlayerMain = this.gameObject.GetComponent<PlayerMain>();
        this.PlayerMove = this.gameObject.GetComponent<PlayerMove>();
        this.PlayerSearch = this.gameObject.GetComponent<PlayerSearch>();

        this.Status = new Dictionary<StatusType, int>();
        this.Effect = new Dictionary<EffectType, bool>();
        this.Inventory = new Dictionary<ItemType, IGameItem>();
        
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
        
        //this.Inventory.Add(ItemType.TORCH, new GameItemFireTool());
        // TODO: JSON -> Value Edit
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

    public void StatusUpdate(int value) {
        foreach (var VARIABLE in this.Status) {
            Debug.Log(VARIABLE.Value);
        }
        
        for (int i = 0; i < this.Status.Count; i++) {
            this.Status[(StatusType)i] += value;
        }

        foreach (var VARIABLE in this.Status) {
            Debug.Log(VARIABLE.Value);
        }
    }

    public void StatusUpdate(int stamina, int bodyHeat, int hydration, int calories) {
        
    }
}