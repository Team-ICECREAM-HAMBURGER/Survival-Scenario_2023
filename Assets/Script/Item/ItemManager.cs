using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] public List<ItemSpawn> FarmingItems { get; private set; }
    [field: SerializeField] public List<ItemSpawn> HuntingItems { get; private set; }
    [field: SerializeField] public List<ItemCraft> CraftingItems { get; private set; }
    
    
    private void Init() {
        // Farming Spawn Items Init();
        this.FarmingItems = SpawnItemsInit(this.FarmingItems);

        // Hunting Spawn Items Init();
        this.HuntingItems = SpawnItemsInit(this.HuntingItems);
        
        // Crafting Spawn Items Init();
        // this.craftingSpawnItems = CraftItemsInit(this.craftingSpawnItems);
    }
    
    private void Start() {
        Init();
    }

    private List<ItemSpawn> SpawnItemsInit(List<ItemSpawn> values) {
        var totalPercent = 0f;

        // 퍼센트 총합 계산
        foreach (var VARIABLE in values) {
            totalPercent += VARIABLE.randomPercent;
        }

        // 퍼센트를 가중치 값으로 전환; 0 ~ 1 
        foreach (var VARIABLE in values) {
            VARIABLE.randomWeight = (VARIABLE.randomPercent / totalPercent);
        }

        return values.OrderBy(i => i.randomWeight).ToList();
    }

    // private List<ItemCraft> CraftItemsInit(List<ItemCraft> values) { }
}