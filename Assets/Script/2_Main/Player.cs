using System.Collections.Generic;
using System.Linq;
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
    
    public List<IPlayerStatusEffect> StatusEffect { get; private set; }
    public List<IPlayerStatus> Status { get; private set; }
    public List<IItem> Inventory { get; private set; }
    
    private readonly Dictionary<StatusEffectType, IPlayerStatusEffect> statusEffectDictionary = new Dictionary<StatusEffectType, IPlayerStatusEffect>() {
            { StatusEffectType.INJURED, new PlayerStatusEffectInjured() },
            { StatusEffectType.EXHAUSTION, new PlayerStatusEffectExhaustion() },
            { StatusEffectType.DEHYDRATION, new PlayerStatusEffectExhaustion() },
            { StatusEffectType.HYPOTHERMIA, new PlayerStatusEffectHypothermia() }
        };
    private readonly Dictionary<StatusType, IPlayerStatus> statusDictionary = new Dictionary<StatusType, IPlayerStatus>() {
        { StatusType.STAMINA, new PlayerStatusStamina() },
        { StatusType.BODY_HEAT, new PlayerStatusBodyHeat() },
        { StatusType.HYDRATION, new PlayerStatusHydration() },
        { StatusType.CALORIES, new PlayerStatusCalories() }
    };
    private readonly Dictionary<ItemType, IItem> inventoryDictionary = new Dictionary<ItemType, IItem>() {
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
        
        // TODO: Save & Load
        this.StatusReduceMultiplier = 1f;
        this.StatusEffect = new List<IPlayerStatusEffect>();
        this.Status = new List<IPlayerStatus>();
        this.Inventory = new List<IItem>();
    }

    private void Awake() {
        Init();
    }
    
    public bool StatusEffectCheck(StatusEffectType type) {  // type 상태 이상 효과가 적용되어 있는가?
        return this.StatusEffect.Any(statusEffect => statusEffect.StatusEffectType == type);
    }
    
    public void StatusEffectAdd(StatusEffectType type) {    // type 상태 이상 효과를 추가
        this.StatusEffect.Add(this.statusEffectDictionary[type]);
    }
    
    public void StatusEffectRemove(StatusEffectType type) { // type 상태 이상 효과를 제거
        this.StatusEffect.Remove(this.statusEffectDictionary[type]);
    }

    public bool StatusCheck(StatusType type, float value) { // type 상태의 수치가 value 이상인가?
        return this.Status.Any(status => status.StatusType == type && status.CurrentValue >= value);
    }

    public bool StatusCheck(float value) {   // 모든 상태의 수치가 value 이상인가?
        return this.Status.All(status => status.CurrentValue >= value);
    }

    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return this.Status.All(status => (status.StatusType == StatusType.STAMINA && status.CurrentValue >= stamina) ||
                                         (status.StatusType == StatusType.BODY_HEAT && status.CurrentValue > bodyHeat) ||
                                         (status.StatusType == StatusType.HYDRATION && status.CurrentValue > hydration) ||
                                         (status.StatusType == StatusType.CALORIES && status.CurrentValue > calories));
    }

    public void StatusUpdate(StatusType type, float value) {    // type 상태의 수치를 value만큼 변경
        
    }
}