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
    
    public UnityEvent OnItemCountUpdate;
    
    
    private void Init() {
        this.Item = new();
        this.OnItemInit = new();
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

    public void ItemAdd((GameControlType.Item, int) value) {
        this.Item[value.Item1].ItemAdd(value.Item2);
    }
}