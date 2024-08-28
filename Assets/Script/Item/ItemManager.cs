using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] private GameControlDictionary.Item ItemPrefab { get; set; }
    [HideInInspector] public GameControlDictionary.Item ItemObject { get; private set; }
    [HideInInspector] public UnityEvent<GameControlDictionary.Inventory> OnInventorySync;

    [Space(25f)]

    [Header("UI Component")]
    public TMP_Text itemInfoTitle;
    public TMP_Text itemInfoExplanation;
    
    [Space(10f)]
    
    public Transform itemInventoryListViewContent;
    
    
    private void Init() {
        this.ItemObject = new();
        
        // Items Init
        foreach (var VARIABLE in this.ItemPrefab) {
            Instantiate(VARIABLE.Value.gameObject, this.itemInventoryListViewContent);
        }
    }
    
    private void Awake() {
        Init();
    }

    public void InventorySync(GameControlDictionary.Inventory value) {
        this.OnInventorySync.Invoke(value);
    }

    public void ItemUse((GameControlType.Item, int) value) {
        if (Player.Instance.Inventory.ContainsKey(value.Item1) && Player.Instance.Inventory[value.Item1] >= value.Item2) {
            this.ItemObject[value.Item1].ItemUse(value.Item2);
            Player.Instance.Inventory[value.Item1] -= value.Item2;
        }
    }

    public string ItemAdd((GameControlType.Item, int) value) {
        this.ItemObject[value.Item1].ItemAdd(value.Item2);
        Player.Instance.Inventory[value.Item1] += value.Item2;

        return this.ItemObject[value.Item1].itemInfoTitleText;
    }

    public void ItemDrop((GameControlType.Item, int) value) {
        if (Player.Instance.Inventory.ContainsKey(value.Item1) && Player.Instance.Inventory[value.Item1] >= value.Item2) {
            this.ItemObject[value.Item1].ItemDrop(value.Item2);
            Player.Instance.Inventory[value.Item1] -= value.Item2;
        }
    }
    
    public string GetItemName(GameControlType.Item type) {
        return this.ItemObject[type].itemInfoTitleText;
    }
}