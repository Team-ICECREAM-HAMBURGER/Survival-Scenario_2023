using System.Collections.Generic;
using UnityEngine;

public class Player : GameContolSingleton<Player> { // Model
    private PlayerInformation information;
    private Dictionary<GameTypeStatus, IPlayerStatus> status;
    private Dictionary<GameTypeStatusEffect, IPlayerStatusEffect> statusEffect;
    private Dictionary<string, int> inventory;

    
    private void Init() {
        this.information = GameInformation.Instance.playerInformation;
        this.status = this.information.status;
        this.statusEffect = this.information.statusEffect;
        this.inventory = this.information.inventory;

        // Debug
        foreach (var VARIABLE in this.inventory) {
            Debug.Log(VARIABLE.Key + " : " + VARIABLE.Value);
        }
    }

    private void Start() {
        Init();
    }
    
    // type 상태의 수치가 value 이상인가?
    public bool StatusCheck(GameTypeStatus type, float value) { 
        return (this.status[type].CurrentValue >= value);
    }

    // 모든 상태의 수치가 value 이상인가?
    public bool StatusCheck(float value) {
        return (this.status[GameTypeStatus.STAMINA].CurrentValue >= value &&
                this.status[GameTypeStatus.BODY_HEAT].CurrentValue >= value &&
                this.status[GameTypeStatus.CALORIES].CurrentValue >= value &&
                this.status[GameTypeStatus.HYDRATION].CurrentValue >= value);
    }
    
    // 각 상태의 수치가 모두 기준치를 넘는가?
    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return (this.status[GameTypeStatus.STAMINA].CurrentValue >= stamina &&
                this.status[GameTypeStatus.BODY_HEAT].CurrentValue >= bodyHeat &&
                this.status[GameTypeStatus.CALORIES].CurrentValue >= hydration &&
                this.status[GameTypeStatus.HYDRATION].CurrentValue >= calories);
    }

    // 각 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(float stamina, float bodyHeat, float hydration, float calories) {
        this.status[GameTypeStatus.STAMINA].CurrentValue += stamina;
        this.status[GameTypeStatus.BODY_HEAT].CurrentValue += bodyHeat;
        this.status[GameTypeStatus.HYDRATION].CurrentValue += hydration;
        this.status[GameTypeStatus.CALORIES].CurrentValue += calories;
    }

    // type 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(GameTypeStatus type, float value) {
        this.status[type].CurrentValue += value;
    }
    
    // type 상태 이상 효과가 적용되어 있는가?
    public bool StatusEffectCheck(GameTypeStatusEffect type) {
        return this.statusEffect.ContainsKey(type);
    }
    
    // 인벤토리에 type 아이템이 존재하는가?
    public bool InventoryCheck(string type) {
        return this.inventory.ContainsKey(type);
    }
    
    // 인벤토리에 type 아이템들을 업데이트
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
}