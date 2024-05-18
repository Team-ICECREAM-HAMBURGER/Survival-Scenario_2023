using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : GameControlSingleton<Player> { // Model
    [SerializeField] private GameObject playerStatus;
    [SerializeField] private GameObject playerStatusEffect;
    [SerializeField] private GameObject playerBehaviour;
    
    private UnityEvent OnStatusUpdate;          // 상태 수치 변동
    private UnityEvent OnStatusEffectUpdate;    // 상태 이상 효과 발동

    private PlayerInformation information;
    public GameControlDictionary.Inventory Inventory { get; private set; }         // <Enum, amount>
    public GameControlDictionary.Status Status { get; private set; }               // <Enum, float>
    public GameControlDictionary.StatusEffect StatusEffect { get; private set; }   // <Enum, term>
    
    
    private void Init() {
        try {
            this.information = GameInformationManager.Instance.playerInformation;
            this.Inventory = this.information.inventory;
            this.Status = this.information.status;
            this.StatusEffect = this.information.statusEffect;

            this.OnStatusUpdate = new();
            this.OnStatusEffectUpdate = new();
            
            foreach (var VARIABLE in this.playerStatus.GetComponents<IPlayerStatus>()) {
                VARIABLE.Init();
                this.OnStatusUpdate.AddListener(VARIABLE.StatusUpdate);
            }

            foreach (var VARIABLE in this.playerStatusEffect.GetComponents<IPlayerStatusEffect>()) {
                VARIABLE.Init();
                
                if (this.StatusEffect.ContainsKey(VARIABLE.Type)) {
                    this.OnStatusEffectUpdate.AddListener(VARIABLE.StatusEffectUpdate);
                }
            }
        }
        catch (NullReferenceException e) {
            Debug.Log("Game Over");
        }
    }
    
    private void Awake() {
    }
    
    private void Start() {  
        Init();
    }

    public void StatusUpdate(GameControlType.Status type, float value) {
        this.Status[type] += Mathf.Floor(value);
        this.Status[type] = Mathf.Clamp(this.Status[type], 0f, 100f);
        
        this.OnStatusUpdate.Invoke();
    }

    public void StatusUpdate(float stamina, float bodyHeat, float hydration, float calories) {
        this.Status[GameControlType.Status.STAMINA] += Mathf.Floor(stamina);
        this.Status[GameControlType.Status.BODY_HEAT] += Mathf.Floor(bodyHeat);
        this.Status[GameControlType.Status.HYDRATION] += Mathf.Floor(hydration);
        this.Status[GameControlType.Status.CALORIES] += Mathf.Floor(calories);

        this.Status[GameControlType.Status.STAMINA] =
            Mathf.Clamp(this.Status[GameControlType.Status.STAMINA], 0f, 100f);
        this.Status[GameControlType.Status.BODY_HEAT] =
            Mathf.Clamp(this.Status[GameControlType.Status.BODY_HEAT], 0f, 100f);
        this.Status[GameControlType.Status.HYDRATION] =
            Mathf.Clamp(this.Status[GameControlType.Status.HYDRATION], 0f, 100f);
        this.Status[GameControlType.Status.CALORIES] =
            Mathf.Clamp(this.Status[GameControlType.Status.CALORIES], 0f, 100f);
        
        this.OnStatusUpdate.Invoke();
    }

    public void StatusEffectAdd(IPlayerStatusEffect effect) {
        if (!this.StatusEffect.TryAdd(effect.Type, effect.Term)) {
            this.StatusEffect[effect.Type] = effect.Term;
            this.OnStatusEffectUpdate.AddListener(effect.StatusEffectUpdate);
        }
    }
    
    public void StatusEffectUpdate() {
        this.OnStatusEffectUpdate?.Invoke();
    }
    
    public void StatusEffectRemove(IPlayerStatusEffect effect) {
        if (this.StatusEffect.ContainsKey(effect.Type)) {
            this.StatusEffect.Remove(effect.Type);
            this.OnStatusEffectUpdate.RemoveListener(effect.StatusEffectUpdate);
        }
    }

    public void InventoryUpdate(Dictionary<IItem, int> items) {
        foreach (var VARIABLE in items) {
            if (!this.Inventory.TryAdd(VARIABLE.Key.Type, VARIABLE.Value)) {
                this.Inventory[VARIABLE.Key.Type] += VARIABLE.Value;
                
                if (this.Inventory[VARIABLE.Key.Type] <= 0) {
                    this.Inventory.Remove(VARIABLE.Key.Type);
                }
            }
        }
    }

    public void InventoryUpdate(GameControlType.Item type, int value) {
        if (!this.Inventory.TryAdd(type, value)) {
            this.Inventory[type] += value;
            
            if (this.Inventory[type] <= 0) {
                this.Inventory.Remove(type);
            }
        }
    }
}