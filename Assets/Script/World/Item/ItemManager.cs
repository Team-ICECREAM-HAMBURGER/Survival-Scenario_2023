using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] private GameControlDictionary.ItemFood itemFoods;
    [field: SerializeField] private GameControlDictionary.ItemMaterial itemMaterials;
    [field: SerializeField] private GameControlDictionary.ItemTool itemTools;
    
    [Space(25f)]
    
    [SerializeField] private Transform inventoryViewPortContent;
    
    public Dictionary<GameControlType.Item, IItem> Items { get; private set; }
    
    private float randomPercentSum;
    
    private UnityEvent<float> OnItemInit;
    
    
    private void Init() {
        this.Items = new();
        this.OnItemInit = new();
        this.randomPercentSum = 0;
        
        foreach (var VARIABLE in this.itemFoods) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);

            var itemObj = Instantiate(VARIABLE.Value.gameObject, this.inventoryViewPortContent);
        }
        
        foreach (var VARIABLE in this.itemMaterials) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
            
            var itemObj = Instantiate(VARIABLE.Value.gameObject, this.inventoryViewPortContent);
        }
        
        foreach (var VARIABLE in this.itemTools) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
            
            var itemObj = Instantiate(VARIABLE.Value.gameObject, this.inventoryViewPortContent);
        }
        
        this.OnItemInit.Invoke(this.randomPercentSum);
    }
    
    private void Awake() {
        Init();
    }
}