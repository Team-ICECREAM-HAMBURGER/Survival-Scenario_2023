using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] private GameControlDictionary.ItemFood itemFoods;
    [field: SerializeField] private GameControlDictionary.ItemMaterial itemMaterials;
    [field: SerializeField] private GameControlDictionary.ItemTool itemTools;

    private float randomPercentSum;
    private Dictionary<GameControlType.Item, IItem> items;
    
    private UnityEvent<float> OnItemInit;
    
    
    private void Init() {
        this.items = new();
        this.OnItemInit = new();
        this.randomPercentSum = 0;
        
        foreach (var VARIABLE in this.itemFoods) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        foreach (var VARIABLE in this.itemMaterials) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        foreach (var VARIABLE in this.itemTools) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        this.OnItemInit.Invoke(this.randomPercentSum);
    }
    
    private void Awake() {
        Init();
    }

    public Dictionary<string, int> RandomItemGet(int value) {
        Dictionary<string, int> result = new();
        
        for (var i = 0; i < value; i++) {
            var pivot = Random.Range(0, 1f);
            var sum = 0f;

            foreach (var VARIABLE in this.items.Values) {
                sum += VARIABLE.RandomWeight;

                if (sum >= pivot) {
                    // 획득
                    if (!result.TryAdd(VARIABLE.Name, Random.Range(1, VARIABLE.RandomMaxValue + 1))) {
                        result[VARIABLE.Name] += Random.Range(1, VARIABLE.RandomMaxValue + 1);
                    }
                    break;
                }
            }
        }
        
        return result;
    }
}