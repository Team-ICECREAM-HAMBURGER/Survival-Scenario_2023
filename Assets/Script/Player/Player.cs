using System;
using UnityEngine;

public class Player : GameControlSingleton<Player> { // Model
    [SerializeField] private PlayerInformation playerInformation;
    
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
    

    private void Init() {
        try {
            this.informationData = GameInformationManager.Instance.playerInformationData;
            this.Inventory = this.informationData.inventory;
            this.Status = this.informationData.status;
            this.StatusEffect = this.informationData.statusEffect;
            this.PlayerName = this.informationData.name;
            this.PlayerID = this.informationData.id;
            
            // TODO: 2024.07.07 --
            this.playerInformation.Init();

            PlayerStatusManager.Instance.Init();
            PlayerStatusEffectManager.Instance.Init();
            PlayerBehaviourManager.Instance.Init();
        }
        catch (NullReferenceException e) {
            Debug.Log("Game Over");
        }
    }
    
    private void Awake() {
        Init();
    }

    public void InventoryUpdate(GameControlType.Item type, int value) {
        if (!this.Inventory.TryAdd(type, value)) {
            this.Inventory[type] += value;
        }
    }
}