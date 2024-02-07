using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public enum StatusType {
    STAMINA,
    BODY_HEAT,
    HYDRATION,
    CALORIES
}

public enum StatusEffectType {
    INJURED,
    HYPOTHERMIA,
    DEHYDRATION,
    EXHAUSTION,
    HEALING,
    ADRENALINE
}

public enum ItemType {
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
    CLOTH,
    STONE,
}

public class Player : MonoBehaviour {
    public static Player Instance;
    
    public float StatusReduceMultiplier { get; set; }
    public List<IPlayerStatusEffect> CurrentStatusEffects { get; private set; }

    public readonly Dictionary<StatusEffectType, IPlayerStatusEffect> StatusEffect = new Dictionary<StatusEffectType, IPlayerStatusEffect>() {
            { StatusEffectType.HEALING, new PlayerStatusEffectHealing() },
            { StatusEffectType.INJURED, new PlayerStatusEffectInjured() },
            { StatusEffectType.ADRENALINE, new PlayerStatusEffectAdrenaline() },
            { StatusEffectType.EXHAUSTION, new PlayerStatusEffectExhaustion() },
            { StatusEffectType.DEHYDRATION, new PlayerStatusEffectExhaustion() },
            { StatusEffectType.HYPOTHERMIA, new PlayerStatusEffectHypothermia() }
        };
    public readonly Dictionary<StatusType, float> Status = new Dictionary<StatusType, float>() {
        { StatusType.STAMINA, 100f },
        { StatusType.BODY_HEAT, 100f },
        { StatusType.HYDRATION, 100f },
        { StatusType.CALORIES, 100f }
    };
    public readonly Dictionary<ItemType, IItem> Inventory = new Dictionary<ItemType, IItem>() {
            { ItemType.HERBS, new ItemHerbs() },
            { ItemType.ROPE, new ItemRope() },
            { ItemType.CAN, new ItemCan() },
            { ItemType.CLOTH, new ItemCloth() },
            { ItemType.PLASTIC_BAG, new ItemPlasticBag() },
            { ItemType.MISCELLANEOUS, new ItemMiscellaneous() },
            { ItemType.STONE, new ItemStone() },
            { ItemType.WOOD, new ItemWood() },
            { ItemType.MRE, new ItemMre() },
            { ItemType.TORCH, new ItemTorch() },
            { ItemType.RAW_MEAT, new ItemMeatRaw() },
            { ItemType.COOKED_MEAT, new ItemMeatCooked() },
            { ItemType.FIRE_TOOL, new ItemFireTool() },
            { ItemType.KINDLING, new ItemKindling() },
            { ItemType.MEDICINE, new ItemMedicine() },
            { ItemType.EMPTY_BOTTLE, new ItemBottleEmpty() },
            { ItemType.FILLED_BOTTLE, new ItemBottleFilled() },
            { ItemType.HUNTING_TOOL, new ItemHuntingTool() }
        };
    
    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;
        
        // TODO: Json Save File Load
        this.StatusReduceMultiplier = 1f;
        this.CurrentStatusEffects = new List<IPlayerStatusEffect>();
    }

    private void Awake() {
        Init();
    }
    
    public void StatusUpdate(float value) {
        for (var i = 0; i < this.Status.Count; i++) {
            this.Status[(StatusType)i] = Mathf.Clamp(this.Status[(StatusType)i] + value * this.StatusReduceMultiplier, 0, 100);
        }
        
        PlayerInfoView.OnPlayerStatusInfoUpdateEvent(this.Status);
    }

    public void StatusUpdate(float stamina, float bodyHeat, float hydration, float calories) {
        float[] values = { stamina, bodyHeat, hydration, calories };
        
        for (var i = 0; i < this.Status.Count; i++) {
            this.Status[(StatusType)i] = Mathf.Clamp(this.Status[(StatusType)i] + values[i] * this.StatusReduceMultiplier, 0, 100);
        }
        
        PlayerInfoView.OnPlayerStatusInfoUpdateEvent(this.Status);
    }

    public bool StatusCheck(float value) {
        return this.Status.All(statusEntry =>
            (statusEntry.Key == StatusType.STAMINA && statusEntry.Value >= value) ||
            (statusEntry.Key == StatusType.BODY_HEAT && statusEntry.Value > value) ||
            (statusEntry.Key == StatusType.HYDRATION && statusEntry.Value > value) ||
            (statusEntry.Key == StatusType.CALORIES && statusEntry.Value > value));
    }
    
    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return this.Status.All(statusEntry =>
            (statusEntry.Key == StatusType.STAMINA && statusEntry.Value >= stamina) ||
            (statusEntry.Key == StatusType.BODY_HEAT && statusEntry.Value > bodyHeat) ||
            (statusEntry.Key == StatusType.HYDRATION && statusEntry.Value > hydration) ||
            (statusEntry.Key == StatusType.CALORIES && statusEntry.Value > calories));
    }

    public bool StatusCheck(StatusType type, float value) {
        return this.Status[type] > value;
    }
    
    public bool StatusEffectCheck(StatusEffectType type) {
        return this.CurrentStatusEffects.Any(statusEffect => 
            statusEffect.StatusEffectType == type);
    }
    
    public void StatusEffectAdd(IPlayerStatusEffect statusEffect) {
        this.CurrentStatusEffects.Add(statusEffect);
    }
    
    public void StatusEffectRemove(IPlayerStatusEffect statusEffect) {
        this.CurrentStatusEffects.Remove(statusEffect);
    }
}