using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Player : GameControlSingleton<Player> { // Model
    [SerializeField] private PlayerInformation playerInformationMonitor;
    
    [Space(10f)]
    
    // [SerializeField] private GameObject playerStatus;
    // [SerializeField] private GameObject playerStatusEffect;
    [SerializeField] private GameObject playerBehaviour;

    private PlayerInformationData informationData;
    
    private GameControlDictionary.Inventory inventory;
    public GameControlDictionary.Inventory Inventory {
        get {
            return this.inventory;
        }
        set {
            this.inventory = value;
            this.informationData.inventory = value;
        }
    } // <Enum, amount>

    private GameControlDictionary.Status status;
    public GameControlDictionary.Status Status {
        get {
            return this.status;
        }
        set {
            this.status = value;
            this.informationData.status = value;
        }
    } // <Enum, float>

    private GameControlDictionary.StatusEffect statusEffect;
    public GameControlDictionary.StatusEffect StatusEffect {
        get {
            return this.statusEffect;
        }
        set {
            this.statusEffect = value;
            this.informationData.statusEffect = value;
        }
    } // <Enum, term>

    private string playerName;
    public string PlayerName {
        get {
            return this.playerName;
        }
        set { 
            this.playerName = value;
            this.informationData.name = value;
        }
    }

    private int playerID;
    public int PlayerID {
        get {
            return this.playerID;
        }
        set {
            this.playerID = value;
            this.informationData.id = value;
        }
    }
    
    
    // private UnityEvent OnStatusUpdate;          // 상태 수치 변동
    // private UnityEvent<int> OnStatusEffectInvoke;    // 상태 이상 효과 발동
    

    private void Init() {
        try {
            this.informationData = GameInformationManager.Instance.playerInformationData;
            this.Inventory = this.informationData.inventory;
            this.Status = this.informationData.status;
            this.StatusEffect = this.informationData.statusEffect;
            this.PlayerName = this.informationData.name;
            this.PlayerID = this.informationData.id;
            
            // this.OnStatusUpdate = new();
            // this.OnStatusEffectInvoke = new();

            
            // TODO: 2024.07.07 --
            this.playerInformationMonitor.Init();
            
            PlayerStatusManager.Instance.Init();
            
            
            
            
            // foreach (var VARIABLE in this.playerStatus.GetComponents<PlayerStatus>()) {
            //     VARIABLE.Init();
            //     this.OnStatusUpdate.AddListener(VARIABLE.StatusUpdate);
            // }

            // foreach (var VARIABLE in this.playerStatusEffect.GetComponents<PlayerStatusEffect>()) {
            //     VARIABLE.Init();
            //     
            //     if (this.StatusEffect.ContainsKey(VARIABLE.Type)) {
            //         this.OnStatusEffectInvoke.AddListener(VARIABLE.StatusEffect);
            //     }
            // }

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
    
    // public void StatusUpdate(GameControlDictionary.RequireStatus requireStatuses, int sign) {
    //     foreach (var VARIABLE in requireStatuses) {
    //         this.Status[VARIABLE.Key] += Mathf.Floor(VARIABLE.Value * sign);
    //         this.Status[VARIABLE.Key] = Mathf.Clamp(this.Status[VARIABLE.Key], 0f, 100f);
    //     }
    //     
    //     this.OnStatusUpdate.Invoke();
    // }
    
    // public void StatusEffectAdd(PlayerStatusEffect effect) {
    //     if (!this.StatusEffect.TryAdd(effect.Type, effect.Term)) {
    //         this.StatusEffect[effect.Type] = effect.Term;
    //     }
    //     else {
    //         this.OnStatusEffectInvoke.AddListener(effect.StatusEffect);
    //     }
    // }
    
    // public void StatusEffectInvoke(int value) {
    //     this.OnStatusEffectInvoke?.Invoke(value);
    // }

    // public void StatusEffectUpdate(PlayerStatusEffect effect) {
    //     this.StatusEffect[effect.Type] = effect.Term;
    // }

    // public void StatusEffectRemove(PlayerStatusEffect effect) {
    //     if (this.StatusEffect.ContainsKey(effect.Type)) {
    //         this.StatusEffect.Remove(effect.Type);
    //         this.OnStatusEffectInvoke.RemoveListener(effect.StatusEffect);
    //     }
    // }

    public void InventoryUpdate(GameControlType.Item type, int value) {
        if (!this.Inventory.TryAdd(type, value)) {
            this.Inventory[type] += value;
        }
    }
}