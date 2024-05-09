using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : GameControlSingleton<Player> { // Model
    [SerializeField] private GameObject playerStatus;
    [SerializeField] private GameObject playerStatusEffect;
    [SerializeField] private GameObject playerBehaviour;
    
    private UnityEvent onStatusUpdate;          // 상태 수치 변동
    private UnityEvent onStatusEffectActive;    // 상태 이상 효과 발동

    private PlayerInformation information;
    public GameControlDictionary.Inventory Inventory { get; private set; }         // <name, amount>
    public GameControlDictionary.Status Status { get; private set; }               // <Enum, float>
    public GameControlDictionary.StatusEffect StatusEffect { get; private set; }   // <Enum, term>
    
    
    private void Init() {
        try {
            this.information = GameInformationManager.Instance.playerInformation;
            this.Inventory = this.information.inventory;
            this.Status = this.information.status;
            this.StatusEffect = this.information.statusEffect;

            this.onStatusUpdate = new();
            this.onStatusEffectActive = new();
            
            foreach (var VARIABLE in this.playerStatus.GetComponents<IPlayerStatus>()) {
                VARIABLE.Init();
                this.onStatusUpdate.AddListener(VARIABLE.StatusUpdate);
            }

            foreach (var VARIABLE in this.playerStatusEffect.GetComponents<IPlayerStatusEffect>()) {
                if (this.StatusEffect.ContainsKey(VARIABLE.Type)) {
                    VARIABLE.Init();
                    this.onStatusEffectActive.AddListener(VARIABLE.StatusEffectActive);
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
        
        this.onStatusUpdate.Invoke();
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
        
        this.onStatusUpdate.Invoke();
    }

    public void StatusEffectInvoke() {
        this.onStatusEffectActive?.Invoke();
    }
    
    public void StatusEffectAdd(GameControlType.StatusEffect type) {

    }
    
    public void StatusEffectRemove(GameControlType.StatusEffect type) {

    }

    public void InventoryUpdate(Dictionary<string, int> items) {
        foreach (var VARIABLE in items) {
            if (this.Inventory.ContainsKey(VARIABLE.Key)) {
                this.Inventory[VARIABLE.Key] += VARIABLE.Value;
            }
            else {
                this.Inventory[VARIABLE.Key] = VARIABLE.Value;
            }
        }
    }

    public void InventoryUpdate(string item, int value) {
        if (!this.Inventory.TryAdd(item, value)) {
            this.Inventory[item] += value;
        }
    }
}