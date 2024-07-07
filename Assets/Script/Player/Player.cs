using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Player : GameControlSingleton<Player> { // Model
    [SerializeField] private PlayerInformation playerInformation;
    
    [Space(10f)]
    
    [SerializeField] private GameObject playerStatus;
    [SerializeField] private GameObject playerStatusEffect;
    [SerializeField] private GameObject playerBehaviour;

    public GameControlDictionary.Inventory Inventory { get; private set; }         // <Enum, amount>
    public GameControlDictionary.Status Status { get; private set; }               // <Enum, float>
    public GameControlDictionary.StatusEffect StatusEffect { get; private set; }   // <Enum, term>
    
    private string playerName;
    public string PlayerName {
        get {
            return this.playerName;
        }
        private set { 
            this.playerName = value;
            this.informationData.name = value;
        }
    }

    private int playerID;
    public int PlayerID {
        get {
            return this.playerID;
        }
        private set {
            this.playerID = value;
            this.informationData.id = value;
        }
    }
    
    private PlayerInformationData informationData;
    
    private UnityEvent OnStatusUpdate;          // 상태 수치 변동
    private UnityEvent<int> OnStatusEffectInvoke;    // 상태 이상 효과 발동
    

    private void Init() {
        try {
            this.informationData = GameInformationManager.Instance.playerInformationData;
            this.Inventory = this.informationData.inventory;
            this.Status = this.informationData.status;
            this.StatusEffect = this.informationData.statusEffect;
            this.PlayerName = this.informationData.name;
            this.PlayerID = this.informationData.id;
            
            this.OnStatusUpdate = new();
            this.OnStatusEffectInvoke = new();

            // Presenter Init //
            this.playerInformation.Init();

            foreach (var VARIABLE in this.playerStatus.GetComponents<IPlayerStatus>()) {
                VARIABLE.Init();
                this.OnStatusUpdate.AddListener(VARIABLE.StatusUpdate);
            }

            foreach (var VARIABLE in this.playerStatusEffect.GetComponents<IPlayerStatusEffect>()) {
                VARIABLE.Init();
                
                if (this.StatusEffect.ContainsKey(VARIABLE.Type)) {
                    this.OnStatusEffectInvoke.AddListener(VARIABLE.StatusEffect);
                }
            }

            foreach (var VARIABLE in this.playerBehaviour.GetComponents<IPlayerBehaviour>()) {
                VARIABLE.Init();
            }
        }
        catch (NullReferenceException e) {
            Debug.Log("Game Over");
        }
    }
    
    private void Awake() {
        Init();
    }

    public void StatusUpdate(GameControlType.Status type, float value) {
        this.Status[type] += Mathf.Floor(value);
        this.Status[type] = Mathf.Clamp(this.Status[type], 0f, 100f);
        
        this.OnStatusUpdate.Invoke();
    }

    public void StatusUpdate(GameControlDictionary.RequireStatus requireStatuses, int sign) {
        foreach (var VARIABLE in requireStatuses) {
            this.Status[VARIABLE.Key] += Mathf.Floor(VARIABLE.Value * sign);
            this.Status[VARIABLE.Key] = Mathf.Clamp(this.Status[VARIABLE.Key], 0f, 100f);
        }
        
        this.OnStatusUpdate.Invoke();
    }
    
    public void StatusEffectAdd(IPlayerStatusEffect effect) {
        if (!this.StatusEffect.TryAdd(effect.Type, effect.Term)) {
            this.StatusEffect[effect.Type] = effect.Term;
        }
        else {
            this.OnStatusEffectInvoke.AddListener(effect.StatusEffect);
        }
    }
    
    public void StatusEffectInvoke(int value) {
        this.OnStatusEffectInvoke?.Invoke(value);
    }

    public void StatusEffectUpdate(IPlayerStatusEffect effect) {
        this.StatusEffect[effect.Type] = effect.Term;
    }
    
    public void StatusEffectRemove(IPlayerStatusEffect effect) {
        if (this.StatusEffect.ContainsKey(effect.Type)) {
            this.StatusEffect.Remove(effect.Type);
            this.OnStatusEffectInvoke.RemoveListener(effect.StatusEffect);
        }
    }

    public void InventoryUpdate(Dictionary<IItem, int> items) {
        foreach (var VARIABLE in items.Where(VARIABLE => !this.Inventory.TryAdd(VARIABLE.Key.ItemType, VARIABLE.Value))) {
            this.Inventory[VARIABLE.Key.ItemType] += VARIABLE.Value;
        }
    }

    public void InventoryUpdate(GameControlType.Item type, int value) {
        if (!this.Inventory.TryAdd(type, value)) {
            this.Inventory[type] += value;
        }
    }
}