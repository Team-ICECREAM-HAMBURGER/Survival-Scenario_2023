using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {  // Presenter
    public delegate void ItemEventHandler(HashSet<IItem> item);
    public static ItemEventHandler OnItemGet;
    public static ItemEventHandler OnItemUse;
    public static ItemEventHandler OnItemCraft;


    private void Init() {
        OnItemGet += ItemGet;
        OnItemUse += ItemUse;
        OnItemCraft += ItemCraft;
    }

    private void Awake() {
        Init();
    }

    private void ItemGet(HashSet<IItem> items) {
        var acquiredItems = new List<IItem>();

        foreach (var VARIABLE in items) {
            acquiredItems.Add(VARIABLE);
        }
        
        Player.Instance.InventoryUpdate(acquiredItems);
    }

    private void ItemUse(HashSet<IItem> items) {
        var usedItems = new List<IItem>();
        
        Player.Instance.InventoryUpdate(usedItems); 
    }

    private void ItemCraft(HashSet<IItem> items) {
    }
}