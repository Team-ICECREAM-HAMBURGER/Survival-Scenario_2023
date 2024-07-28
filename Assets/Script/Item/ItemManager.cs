using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] public GameControlDictionary.Item Item { get; private set; }
    
    [Space(25f)]
    
    [SerializeField] private UnityEvent OnItemInit;
    
    [HideInInspector] public UnityEvent OnItemCountUpdate;
    
    
    private void Init() {
        this.OnItemCountUpdate = new();
        
        // Items Init
        this.OnItemInit.Invoke();
    }
    
    private void Awake() {
        Init();
    }

    public void ItemCountUpdate() {
        this.OnItemCountUpdate.Invoke();
    }

    public void ItemUse((GameControlType.Item, int) value) {
        this.Item[value.Item1].ItemUse(value.Item2);
    }

    public string ItemAdd((GameControlType.Item, int) value) {
        this.Item[value.Item1].ItemAdd(value.Item2);
        
        return this.Item[value.Item1].Name;
    }

    public string GetItemName(GameControlType.Item type) {
        return this.Item[type].Name;
    }
}