using System.Collections.Generic;
using UnityEngine;

public class Player : GameControlSingleton<Player> { // Model
    private PlayerInformation information;

    private GameControlDictionary.Inventory inventory;
    private GameControlDictionary.Status status;
    private GameControlDictionary.StatusEffect statusEffect;
    
    
    private void Init() {
        this.information = GameInformation.Instance.playerInformation;
        
        this.inventory = this.information.inventory;
        this.status = this.information.status;
        this.statusEffect = this.information.statusEffect;
    }

    private void Start() {
        Init();
    }
    
    // type 상태의 수치가 value 이상인가?
    public bool StatusCheck(GameControlType.Status type, float value) { 
        return (this.status[type].CurrentValue >= value);
    }

    // 모든 상태의 수치가 value 이상인가?
    public bool StatusCheck(float value) {
        return (this.status[GameControlType.Status.STAMINA].CurrentValue >= value &&
                this.status[GameControlType.Status.BODY_HEAT].CurrentValue >= value &&
                this.status[GameControlType.Status.CALORIES].CurrentValue >= value &&
                this.status[GameControlType.Status.HYDRATION].CurrentValue >= value);
    }
    
    // 각 상태의 수치가 모두 기준치를 넘는가?
    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return (this.status[GameControlType.Status.STAMINA].CurrentValue >= stamina &&
                this.status[GameControlType.Status.BODY_HEAT].CurrentValue >= bodyHeat &&
                this.status[GameControlType.Status.CALORIES].CurrentValue >= hydration &&
                this.status[GameControlType.Status.HYDRATION].CurrentValue >= calories);
    }

    // 각 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(float stamina, float bodyHeat, float hydration, float calories) {
        this.status[GameControlType.Status.STAMINA].CurrentValue += stamina;
        this.status[GameControlType.Status.BODY_HEAT].CurrentValue += bodyHeat;
        this.status[GameControlType.Status.HYDRATION].CurrentValue += hydration;
        this.status[GameControlType.Status.CALORIES].CurrentValue += calories;
    }

    // type 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(GameControlType.Status type, float value) {
        this.status[type].CurrentValue += value;
    }
    
    // type 상태 이상 효과가 적용되어 있는가?
    public bool StatusEffectCheck(GameControlType.StatusEffect type) {
        return this.statusEffect.ContainsKey(type);
    }
    
    // type 상태 이상 효과 업데이트
    public void StatusEffectUpdate( value) {
        this.statusEffect.TryAdd(value.StatusEffectType, value);
        
        GameInformation.Instance.PlayerDataSave();
    }
    
    // 인벤토리에 type 아이템이 존재하는가?
    public bool InventoryCheck(string type) {
        return this.inventory.ContainsKey(type);
    }
    
    // 인벤토리에 type 아이템들을 업데이트; ItemGet
    public void InventoryUpdate(Dictionary<string, int> items) {
        foreach (var VARIABLE in items) {
            if (this.inventory.ContainsKey(VARIABLE.Key)) {
                this.inventory[VARIABLE.Key] += VARIABLE.Value;
            }
            else {
                this.inventory[VARIABLE.Key] = VARIABLE.Value;
            }
        }
        
        GameInformation.Instance.PlayerDataSave();
    }

    public void InventoryUpdate(string item, int value) {
        if (!this.inventory.TryAdd(item, value)) {
            this.inventory[item] += value;
        }
    }
}