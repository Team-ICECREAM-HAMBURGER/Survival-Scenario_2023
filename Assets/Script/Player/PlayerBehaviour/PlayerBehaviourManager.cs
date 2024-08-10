using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviourManager : GameControlSingleton<PlayerBehaviourManager> {
    [field: SerializeField] public GameControlDictionary.PlayerBehaviour Behaviour { get; private set; }
    
    [Space(25f)]

    [SerializeField] private UnityEvent OnPlayerBehaviourInit;


    public void Init() {
        // this.OnPlayerBehaviourInit = new();
        this.OnPlayerBehaviourInit.Invoke();
    }
    
    // PlayerBehaviour -> PlayerBehaviourManager -> (OUT) //
    public bool CanBehaviour(List<(GameControlType.Item, int)> values) {
        return values.All(VARIABLE => Player.Instance.Inventory[VARIABLE.Item1] >= VARIABLE.Item2);
    }
    
    public bool CanBehaviour((GameControlType.Item, int) value) {
        return (Player.Instance.Inventory[value.Item1] >= value.Item2);
    }

    public bool CanBehaviour(GameControlType.Behaviour type) {
        return type switch {
            GameControlType.Behaviour.FIRE => World.Instance.HasFire,
            GameControlType.Behaviour.SHELTER => World.Instance.HasShelter,
            GameControlType.Behaviour.RAIN_GUTTER => World.Instance.HasRainGutter,
            GameControlType.Behaviour.SEARCH_HUNT => Player.Instance.Inventory.ContainsKey(GameControlType.Item.HUNTING_TOOL),
            _ => true
        };
    }
    
    public void InventorySync() {
        ItemManager.Instance.InventorySync(Player.Instance.Inventory);
    }

    public int GetInventoryAmountTotal() {
        return Player.Instance.Inventory.Sum(x => x.Value);
    }

    public int GetInventoryAmountItem(GameControlType.Item type) {
        return Player.Instance.Inventory[type];
    }

    public bool GetInventoryContainItem(GameControlType.Item type) {
        return (Player.Instance.Inventory[type] > 0);
    }

    public void ItemUse((GameControlType.Item, int) value) {
        ItemManager.Instance.ItemUse(value);
    }
    
    public string ItemAdd((GameControlType.Item, int) value) {
        return ItemManager.Instance.ItemAdd(value);
    }

    public string GetItemName(GameControlType.Item type) {
        return ItemManager.Instance.GetItemName(type);
    }
    
    public void StatusEffectInvoke() {
        PlayerStatusEffectManager.Instance.StatusEffectInvoke();
    }

    public void StatusEffectAdd(GameControlType.StatusEffect type) {
        PlayerStatusEffectManager.Instance.StatusEffectAdd(type);
    }

    public void WorldTimeUpdate(int time) {
        World.Instance.TimeUpdate(time);
    }

    public void WorldFireSet((bool, int) value) {
        World.Instance.HasFire = value.Item1;
        World.Instance.FireTerm = value.Item2;
    }

    public void WorldRainGutterSet(bool value) {
        World.Instance.HasRainGutter = value;
    }

    public void WorldRainWaterSet(bool value) {
        World.Instance.HasWater = value;
    }
    
    public void WorldShelterSet(bool value) {
        World.Instance.HasShelter = value;
    }

    public void WorldFireTermUpdate(int value) {
        World.Instance.FireTerm += value;
    }

    public int WorldFireTermGet() {
        return World.Instance.FireTerm;
    }

    public bool WorldRainWaterGet() {
        return World.Instance.HasWater;
    }

    public bool WorldCurrentWeatherCheck(GameControlType.Weather type) {
        return (World.Instance.Weather.Item1 == type);
    }

    public void WorldCurrentLocationUpdate(string value) {
        GameInformationMonitorManager.Instance.CurrentLocationUpdate(value);
    }
    
    public void GameDataSaveInvoke() {
        GameInformationManager.Instance.GameDataSaveInvoke();
    }
    
    
    // PlayerBehaviour <- PlayerBehaviourManager <- (OUT) //
}