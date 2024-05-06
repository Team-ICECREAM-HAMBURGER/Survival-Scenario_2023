using System;
using System.Collections.Generic;
using UnityEngine;

/*
 *  IEnumerator Fade(bool isFadeIn) {
        float timer = 0;

        while (timer <= 1) {
            yield return null;
            timer += Time.unscaledDeltaTime * 2f;
            this.sceneLoaderCanvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);
        }

        if (!isFadeIn) {
            gameObject.SetActive(false);
        }
    }
 */
public class Player : GameControlSingleton<Player> { // Model
    private PlayerInformation information;
    private GameControlDictionary.Inventory inventory;          // <name, amount>
    public GameControlDictionary.Status Status { get; private set; }                // <Enum, float>
    public GameControlDictionary.StatusEffect StatusEffect { get; private set; }    // <Enum, term>
    
    public Dictionary<GameControlType.Status, IPlayerStatus> StatusMap { get; private set; }
    public Dictionary<GameControlType.StatusEffect, IPlayerStatusEffect> StatusEffectMap { get; private set; }
    
    private delegate void StatusEffectInvokeHandler(int value);
    private StatusEffectInvokeHandler OnStatusEffectInvoke;
    
    
    private void Init() {
        this.information = GameInformation.Instance.playerInformation;
        
        this.inventory = this.information.inventory;
        this.Status = this.information.status;
        this.StatusEffect = this.information.statusEffect;
        this.StatusMap = new();
        this.StatusEffectMap = new();
        
        foreach (var VARIABLE in GetComponents<IPlayerStatus>()) {
            this.StatusMap[VARIABLE.Type] = VARIABLE;
            this.StatusMap[VARIABLE.Type].Init(this.Status[VARIABLE.Type]);
        }
        
        foreach (var VARIABLE in GetComponents<IPlayerStatusEffect>()) {
            this.StatusEffectMap[VARIABLE.Type] = VARIABLE;
        }
        
        foreach (var VARIABLE in this.StatusEffect) {
            this.StatusEffectMap[VARIABLE.Key].Term = this.StatusEffect[VARIABLE.Key];
            OnStatusEffectInvoke += this.StatusEffectMap[VARIABLE.Key].Invoke;
        }

        foreach (var VARIABLE in this.StatusMap) {
            this.StatusMap[VARIABLE.Key].CurrentValue = this.Status[VARIABLE.Key];
        }
    }

    private void Start() {
        Init();
    }

    // type 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(GameControlType.Status type, float value) {
        this.Status[type] += MathF.Floor(value);
        this.StatusMap[type].Invoke(this.Status[type]);
    }

    // 구독 중인 상태 이상에 효과 알림 전송
    public void StatusEffectInvoke(int value) {
        OnStatusEffectInvoke?.Invoke(value);
    }
    
    // type 상태 이상 효과 추가 
    public void StatusEffectAdd(IPlayerStatusEffect effect) {
        if (!this.StatusEffect.TryAdd(effect.Type, effect.Term)) {  // 이미 있음
            this.StatusEffect[effect.Type] = effect.Term;
        }
        else {  // 신규 할당
            OnStatusEffectInvoke += effect.Invoke;
        }
    }

    public void StatusEffectUpdate(IPlayerStatusEffect effect) {
        this.StatusEffect[effect.Type] = effect.Term;
    }
    
    // type 상태 이상 효과 삭제
    public void StatusEffectRemove(IPlayerStatusEffect effect) {
        this.StatusEffect.Remove(effect.Type);
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