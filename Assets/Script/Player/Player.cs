using System.Collections.Generic;
using UnityEngine;

public class Player : GameControlSingleton<Player> { // Model
    private PlayerInformation information;

    private GameControlDictionary.Inventory inventory;          // <name, amount>
    private GameControlDictionary.Status status;                // <Enum, float>
    private GameControlDictionary.StatusEffect statusEffect;    // <name, term>
    
    private delegate void StatusEffectInvokeHandler(int value);
    private StatusEffectInvokeHandler OnStatusEffectInvoke;
    
    
    private void Init() {
        this.information = GameInformation.Instance.playerInformation;
        
        this.inventory = this.information.inventory;
        this.status = this.information.status;
        this.statusEffect = this.information.statusEffect;

        foreach (var VARIABLE in this.statusEffect) {
            PlayerStatusEffectManager.Instance.StatusEffects[VARIABLE.Key].Term = this.statusEffect[VARIABLE.Key];
            OnStatusEffectInvoke += PlayerStatusEffectManager.Instance.StatusEffects[VARIABLE.Key].Invoke;
        }
    }

    private void Start() {
        Init();
    }
    
    // type 상태의 수치가 value 이상인가?
    public bool StatusCheck(GameControlType.Status type, float value) { 
        return true;
    }

    // 모든 상태의 수치가 value 이상인가?
    public bool StatusCheck(float value) {
        return true;
    }
    
    // 각 상태의 수치가 모두 기준치를 넘는가?
    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return true;
    }

    // 각 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(float[] values) {
    }

    // type 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(GameControlType.Status type, float value) {
        this.status[type] += value;
    }
    
    // type 상태 이상 효과가 적용되어 있는가?
    public bool StatusEffectCheck(string key) { 
        return this.statusEffect.ContainsKey(key);
    }

    // 구독 중인 상태 이상에 효과 알림 전송
    public void StatusEffectInvoke(int value) {
        OnStatusEffectInvoke?.Invoke(value);
    }
    
    // type 상태 이상 효과 추가 
    public void StatusEffectAdd(IPlayerStatusEffect effect) {
        if (!this.statusEffect.TryAdd(effect.Name, effect.Term)) {
            this.statusEffect[effect.Name] = effect.Term;
        }
        else {
            OnStatusEffectInvoke += effect.Invoke;
        }
    }

    public void StatusEffectUpdate(IPlayerStatusEffect effect) {
        this.statusEffect[effect.Name] = effect.Term;
    }
    
    // type 상태 이상 효과 삭제
    public void StatusEffectRemove(IPlayerStatusEffect effect) {
        this.statusEffect.Remove(effect.Name);
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
    }

    public void InventoryUpdate(string item, int value) {
        if (!this.inventory.TryAdd(item, value)) {
            this.inventory[item] += value;
        }
    }
}