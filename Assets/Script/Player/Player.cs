using System;
using System.Collections.Generic;

public class Player : GameControlSingleton<Player> { // Model
    private PlayerInformation information;

    private GameControlDictionary.Inventory inventory;          // <name, amount>
    public GameControlDictionary.Status Status { get; private set; }                // <Enum, float>
    public GameControlDictionary.StatusEffect StatusEffect { get; private set; }    // <name, term>
    
    private delegate void StatusEffectInvokeHandler(int value);
    private StatusEffectInvokeHandler OnStatusEffectInvoke;
    
    
    private void Init() {
        this.information = GameInformation.Instance.playerInformation;
        
        this.inventory = this.information.inventory;
        this.Status = this.information.status;
        this.StatusEffect = this.information.statusEffect;

        foreach (var VARIABLE in this.StatusEffect) {
            PlayerStatusEffectManager.Instance.StatusEffects[VARIABLE.Key].Term = this.StatusEffect[VARIABLE.Key];
            OnStatusEffectInvoke += PlayerStatusEffectManager.Instance.StatusEffects[VARIABLE.Key].Invoke;
        }

        // DEBUG
        this.Status[GameControlType.Status.STAMINA] = 100f;
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
        this.Status[type] += MathF.Floor(value);
    }
    
    // type 상태 이상 효과가 적용되어 있는가?
    public bool StatusEffectCheck(string key) { 
        return this.StatusEffect.ContainsKey(key);
    }

    // 구독 중인 상태 이상에 효과 알림 전송
    public void StatusEffectInvoke(int value) {
        OnStatusEffectInvoke?.Invoke(value);
    }
    
    // type 상태 이상 효과 추가 
    public void StatusEffectAdd(IPlayerStatusEffect effect) {
        if (!this.StatusEffect.TryAdd(effect.Name, effect.Term)) {  // 이미 있음
            this.StatusEffect[effect.Name] = effect.Term;
        }
        else {  // 신규 할당
            OnStatusEffectInvoke += effect.Invoke;
        }
    }

    public void StatusEffectUpdate(IPlayerStatusEffect effect) {
        this.StatusEffect[effect.Name] = effect.Term;
    }
    
    // type 상태 이상 효과 삭제
    public void StatusEffectRemove(IPlayerStatusEffect effect) {
        this.StatusEffect.Remove(effect.Name);
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