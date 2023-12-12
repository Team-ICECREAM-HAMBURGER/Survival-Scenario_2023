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

public enum statusEffectType {
    INJURED,
    HYPOTHERMIA,
    DEHYDRATION,
    EXHAUSTION,
    //
    HEALING,
    ADRENALINE
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

public class Player : MonoBehaviour {
    public static Player Instance;
    
    [SerializeField] private List<Canvas> canvasList;

    public float StatusReduceMultiplier { get; set; } = 1f;
    public PlayerMain PlayerMain { get; private set; }
    public PlayerMove PlayerMove { get; private set; }
    public PlayerSearch PlayerSearch { get; private set; }
    
    public Dictionary<statusType, float> Status { get; private set; }
    public Dictionary<statusEffectType, PlayerStatusEffect> StatusEffect { get; set; }
    
    // TODO: Player -> Item
    public readonly Dictionary<itemType, Item> inventory = 
        new Dictionary<itemType, Item>() {
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
        if (Instance != null) {
            return;
        }
        
        Instance = this;

        this.PlayerMain = this.gameObject.GetComponent<PlayerMain>();
        this.PlayerMove = this.gameObject.GetComponent<PlayerMove>();
        this.PlayerSearch = this.gameObject.GetComponent<PlayerSearch>();

        this.Status = new Dictionary<statusType, float>();
        this.StatusEffect = new Dictionary<statusEffectType, PlayerStatusEffect>();
        this.canvasList = new List<Canvas>();
        
        foreach (GameObject variable in GameObject.FindGameObjectsWithTag("Canvas")) {
            this.canvasList.Add(variable.GetComponent<Canvas>());
        }
        
        // TODO: JSON Load
        this.Status.Add(statusType.STAMINA, 100f);
        this.Status.Add(statusType.BODY_HEAT, 100f);
        this.Status.Add(statusType.HYDRATION, 100f);        
        this.Status.Add(statusType.CALORIES, 100f);

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
    
    // TODO: Player Status Value -> (0 ~ 100)

    public void StatusUpdate(float value) {
        for (int i = 0; i < this.Status.Count; i++) {
            this.Status[(statusType)i] += value * this.StatusReduceMultiplier;
        }
    }

    public void StatusUpdate(float stamina, float bodyHeat, float hydration, float calories) {
        float[] values = { stamina, bodyHeat, hydration, calories };
        
        for (int i = 0; i < this.Status.Count; i++) {
            this.Status[(statusType)i] += values[i] * this.StatusReduceMultiplier;
        }
    }

    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return this.Status.All(statusEntry =>
            (statusEntry.Key == statusType.STAMINA && statusEntry.Value >= stamina) ||
            (statusEntry.Key == statusType.BODY_HEAT && statusEntry.Value > bodyHeat) ||
            (statusEntry.Key == statusType.HYDRATION && statusEntry.Value > hydration) ||
            (statusEntry.Key == statusType.CALORIES && statusEntry.Value > calories));
    }
}