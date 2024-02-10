using System;
using System.Collections.Generic;

public enum StatusType {
    STAMINA,
    BODY_HEAT,
    HYDRATION,
    CALORIES
}

public enum StatusEffectType {
    NO_SHELTER,     // 휴식처가 없음
    NO_FIRE,        // 불이 없음
    INJURED,        // 부상을 입음
    DEHYDRATION,    // 탈수
    EXHAUSTION,     // 탈진
    HYPOTHERMIA     // 저체온증
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

[Serializable]
public class InfoData {
    public string name;

    public Dictionary<ItemType, IItem> inventory;
    public Dictionary<StatusType, IPlayerStatus> status;
    public Dictionary<StatusEffectType, IPlayerStatusEffect> statusEffect;
}


public class Player : Singleton<Player> {
    public InfoData infoData;

    private readonly Dictionary<ItemType, IItem> itemDictionary = new Dictionary<ItemType, IItem> {
        { ItemType.EMPTY_BOTTLE, new ItemBottleEmpty() },
        { ItemType.FILLED_BOTTLE, new ItemBottleFilled() },
        { ItemType.CAN, new ItemCan() },
        { ItemType.CLOTH, new ItemCloth() },
        { ItemType.FIRE_TOOL, new ItemFireTool() },
        { ItemType.HAND_AXE, new ItemHandAxe() },
        { ItemType.HERBS, new ItemHerbs() },
        { ItemType.HUNTING_TOOL, new ItemHuntingTool() },
        { ItemType.KINDLING, new ItemKindling() },
        { ItemType.COOKED_MEAT, new ItemMeatCooked() },
        { ItemType.RAW_MEAT, new ItemMeatRaw() },
        { ItemType.MEDICINE, new ItemMedicine() },
        { ItemType.MISCELLANEOUS, new ItemMiscellaneous() },
        { ItemType.MRE, new ItemMre() },
        { ItemType.PLASTIC_BAG, new ItemPlasticBag() },
        { ItemType.ROPE, new ItemRope() },
        { ItemType.STONE, new ItemStone() },
        { ItemType.TORCH, new ItemTorch() },
        { ItemType.WOOD, new ItemWood() }
    };
    private readonly Dictionary<StatusType, IPlayerStatus> statusDictionary = new Dictionary<StatusType, IPlayerStatus> {
        { StatusType.STAMINA, new PlayerStatusStamina() },
        { StatusType.BODY_HEAT, new PlayerStatusBodyHeat() },
        { StatusType.CALORIES, new PlayerStatusCalories() },
        { StatusType.HYDRATION, new PlayerStatusHydration() }
    };
    private readonly Dictionary<StatusEffectType, IPlayerStatusEffect> statusEffectDictionary = new Dictionary<StatusEffectType, IPlayerStatusEffect> {
        { StatusEffectType.INJURED, new PlayerStatusEffectInjured() },
        { StatusEffectType.EXHAUSTION, new PlayerStatusEffectExhaustion() },
        { StatusEffectType.DEHYDRATION, new PlayerStatusEffectDehydration() },
        { StatusEffectType.HYPOTHERMIA, new PlayerStatusEffectHypothermia() }
    };
    
    
    private void Init() {
        // TODO: Json Load/Save
        if (!GameSaveLoadControl.Instance.SaveFileCheck()) {    // 새로 시작
            this.infoData = new InfoData {
                name = String.Empty,
                inventory = new Dictionary<ItemType, IItem>(),
                status = new Dictionary<StatusType, IPlayerStatus> {
                    { StatusType.STAMINA, new PlayerStatusStamina() },
                    { StatusType.CALORIES, new PlayerStatusCalories() },
                    { StatusType.BODY_HEAT, new PlayerStatusBodyHeat() },
                    { StatusType.HYDRATION, new PlayerStatusHydration() }
                },
                statusEffect = new Dictionary<StatusEffectType, IPlayerStatusEffect>()
            };
        }
        else {  // 파일 로드
            this.infoData = GameSaveLoadControl.Instance.LoadSaveFile<InfoData>();
        }
    }

    private void Awake() {
        Init();
    }

    public bool InventoryCheck(ItemType type) {
        return this.infoData.inventory.ContainsKey(type);
    }

    public void InventoryAdd(ItemType type) {
        if (InventoryCheck(type)) {
            return;
        }
        
        this.infoData.inventory.Add(type, this.itemDictionary[type]);
    }

    public void InventoryRemove(ItemType type) {
        if (!InventoryCheck(type)) {
            return;
        }

        this.infoData.inventory.Remove(type);
    }
    
    public bool StatusEffectCheck(StatusEffectType type) {  // type 상태 이상 효과가 적용되어 있는가?
        return this.infoData.statusEffect.ContainsKey(type);
    }
    
    public void StatusEffectAdd(StatusEffectType type) {    // type 상태 이상 효과를 추가
        if (StatusEffectCheck(type)) {
            return;
        }
        
        this.infoData.statusEffect.Add(type, this.statusEffectDictionary[type]);
    }
    
    public void StatusEffectRemove(StatusEffectType type) { // type 상태 이상 효과를 제거
        if (StatusEffectCheck(type)) {
            this.infoData.statusEffect.Remove(type);
        }
    }

    public bool StatusCheck(StatusType type, float value) { // type 상태의 수치가 value 이상인가?
        return this.infoData.status[type].CurrentValue >= value;
    }

    public bool StatusCheck(float value) {  // 모든 상태의 수치가 value 이상인가?
        return this.infoData.status[StatusType.STAMINA].CurrentValue >= value &&
               this.infoData.status[StatusType.BODY_HEAT].CurrentValue >= value &&
               this.infoData.status[StatusType.HYDRATION].CurrentValue >= value &&
               this.infoData.status[StatusType.CALORIES].CurrentValue >= value;
    }

    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {   // 각 상태의 수치가 기준치를 넘는가?
        return this.infoData.status[StatusType.STAMINA].CurrentValue >= stamina &&
               this.infoData.status[StatusType.BODY_HEAT].CurrentValue >= bodyHeat &&
               this.infoData.status[StatusType.HYDRATION].CurrentValue >= hydration &&
               this.infoData.status[StatusType.CALORIES].CurrentValue >= calories;
    }

    public void StatusUpdate(StatusType type, float value) {    // type 상태의 수치를 value만큼 변경
        this.infoData.status[type].StatusIncrease(value);
    }
}