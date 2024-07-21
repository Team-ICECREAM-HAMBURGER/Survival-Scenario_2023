using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : GameControlSingleton<Player> { // Model
    [SerializeField] private GameInformationMonitorPlayer gameInformationMonitorPlayer;
    
    private GameInformationPlayerData data;
    
    private GameControlDictionary.Inventory inventory;
    public GameControlDictionary.Inventory Inventory {
        get {
            return this.inventory;
        }
        set {
            this.inventory = value;
            this.data.inventory = value;
        }
    } // <Enum, amount>

    private GameControlDictionary.Status status;
    public GameControlDictionary.Status Status {
        get {
            return this.status;
        }
        set {
            this.status = value;
            this.data.status = value;
        }
    } // <Enum, float>

    private GameControlDictionary.StatusEffect statusEffect;
    public GameControlDictionary.StatusEffect StatusEffect {
        get {
            return this.statusEffect;
        }
        set {
            this.statusEffect = value;
            this.data.statusEffect = value;
        }
    } // <Enum, term>

    private string playerName;
    public string PlayerName {
        get {
            return this.playerName;
        }
        set { 
            this.playerName = value;
            this.data.name = value;
        }
    }

    private int playerID;
    public int PlayerID {
        get {
            return this.playerID;
        }
        set {
            this.playerID = value;
            this.data.id = value;
        }
    }
    

    private void Init() {
        try {
            this.data = GameInformationManager.Instance.gameInformationPlayerData;
            this.Inventory = this.data.inventory;
            this.Status = this.data.status;
            this.StatusEffect = this.data.statusEffect;
            this.PlayerName = this.data.name;
            this.PlayerID = this.data.id;
            
            this.gameInformationMonitorPlayer.Init();

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
}