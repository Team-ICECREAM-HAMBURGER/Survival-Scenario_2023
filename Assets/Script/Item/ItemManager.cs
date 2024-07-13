using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [SerializeField] private Transform inventoryViewPortContent;

    [field: SerializeField] public GameControlDictionary.ItemFood ItemFoods { get; private set; }
    [field: SerializeField] public GameControlDictionary.ItemMaterial ItemMaterials { get; private set; }
    [field: SerializeField] public GameControlDictionary.ItemTool ItemTools { get; private set; }
    
    public Dictionary<GameControlType.Item, IItem> Items { get; private set; }
    public Dictionary<GameControlType.Item, IItem> FarmItems { get; private set; }
    public Dictionary<GameControlType.Item, IItem> HuntItems { get; private set; }
    public Dictionary<GameControlType.Item, IItem> CraftItems { get; private set; }
    public Dictionary<GameControlType.Item, IItem> CookItems { get; private set; }
    public Dictionary<GameControlType.Item, IItem> WaterItems { get; private set; }
    
    private float percentSum;
    private float percentLimit;
    private float pivot;
    private float pivotSum;
    
    private UnityEvent<Transform> OnItemInit;
    
    
    private void Init() {
        this.Items = new();
        this.FarmItems = new();
        this.HuntItems = new();
        this.CraftItems = new();
        this.CookItems = new();
        this.WaterItems = new();

        this.OnItemInit = new();
        
        this.percentSum = 0f;
        this.percentLimit = 0f;
        this.pivot = 0f;
        this.pivotSum = 0f;
        
        // Items Dictionary Init;
        ItemDictionaryInit();
        
        // Sorting By Item Get Type
        ItemGetTypeSort();
        
        // Calculating Item Random Weight
        ItemRandomWeightCalculate(this.FarmItems);
        ItemRandomWeightCalculate(this.HuntItems);

        // All Items INIT
        this.OnItemInit.Invoke(this.inventoryViewPortContent);
    }
    
    private void Awake() {
        Init();
    }

    public Dictionary<IItem, int> RandomItemWeightSelect(int value, Dictionary<GameControlType.Item, IItem> target) {
        var result = new Dictionary<IItem, int>();
        
        for (var i = 0; i < value; i++) {
            this.pivot = Random.Range(0f, 1f);
            this.pivotSum = 0f;
            
            foreach (var VARIABLE in target.Values) {
                this.pivotSum += VARIABLE.RandomWeight;
    
                if (this.pivotSum >= pivot) {
                    // 획득
                    if (!result.TryAdd(VARIABLE, Random.Range(1, VARIABLE.RandomMaxValue + 1))) {
                        result[VARIABLE] += Random.Range(1, VARIABLE.RandomMaxValue + 1);
                    }
                    
                    break;
                }
            }
        }
        
        return result;
    }
    
    private void ItemDictionaryInit() {
        foreach (var VARIABLE in this.ItemFoods) {
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        foreach (var VARIABLE in this.ItemMaterials) {
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        foreach (var VARIABLE in this.ItemTools) {
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
        }
    }

    private void ItemGetTypeSort() {
        foreach (var VARIABLE in this.Items) {  
            switch (VARIABLE.Value.ItemGetType) {
                case GameControlType.Behaviour.FARM :
                    this.FarmItems[VARIABLE.Key] = VARIABLE.Value;
                    
                    break;
                
                case GameControlType.Behaviour.HUNT :
                    this.HuntItems[VARIABLE.Key] = VARIABLE.Value;
                    
                    break;
                
                case GameControlType.Behaviour.CRAFT :
                    this.CraftItems[VARIABLE.Key] = VARIABLE.Value;
                    
                    break;
                
                case GameControlType.Behaviour.COOK :
                    this.CookItems[VARIABLE.Key] = VARIABLE.Value;
                    
                    break;
                case GameControlType.Behaviour.WATER:
                    this.WaterItems[VARIABLE.Key] = VARIABLE.Value;
                    
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void ItemRandomWeightCalculate(Dictionary<GameControlType.Item, IItem> target) {
        var sumPercent = 0f;

        sumPercent = target.Sum(VARIABLE => VARIABLE.Value.RandomPercent);

        foreach (var VARIABLE in target) {
            VARIABLE.Value.RandomWeight = (VARIABLE.Value.RandomPercent / sumPercent);
        }
    }
}