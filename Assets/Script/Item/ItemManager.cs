using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [SerializeField] private List<GameObject> farmingSpawnItemPrefabs;
    [SerializeField] private List<GameObject> huntingSpawnItemPrefabs;
    [SerializeField] private List<GameObject> craftingSpawnItemPrefabs;

    private List<ItemSpawnFarming> farmingSpawnItems;
    private List<ItemSpawnCrafting> craftingSpawnItems;
    private List<ItemSpawnHunting> huntingSpawnItems;
    
    
    private void Init() {
        this.farmingSpawnItems = new();
        this.craftingSpawnItems = new();
        this.huntingSpawnItems = new();
        
        // Farming Spawn Items Init();
        FarmingSpawnItemsInit();

        // Crafting Spawn Items Init();

        // Hunting Spawn Items Init();
        HuntingSpawnItemsInit();
    }

    private void FarmingSpawnItemsInit() {
        var totalPercent = 0f;
        
        foreach (var VARIABLE in this.farmingSpawnItemPrefabs) {    // 클래스 리스트 생성 + % 총합
            var item = VARIABLE.GetComponent<ItemSpawnFarming>();
            
            this.farmingSpawnItems.Add(item);
            totalPercent += item.randomPercent;
        }

        foreach (var VARIABLE in this.farmingSpawnItems) {  // 가중치 계산
            VARIABLE.randomWeight = (VARIABLE.randomPercent / totalPercent);
        }

        this.farmingSpawnItems = this.farmingSpawnItems.OrderBy(i => i.randomWeight).ToList(); // 정렬
    }

    private void CraftingSpawnItemsInit() {
    }

    private void HuntingSpawnItemsInit() {
        var totalPercent = 0f;

        foreach (var VARIABLE in this.huntingSpawnItemPrefabs) {
            var item = VARIABLE.GetComponent<ItemSpawnHunting>();
            
            this.huntingSpawnItems.Add(item);
            totalPercent += item.randomPercent;
        }

        foreach (var VARIABLE in this.huntingSpawnItems) {  // 가중치 계산
            VARIABLE.randomWeight = (VARIABLE.randomPercent / totalPercent);
        }

        this.huntingSpawnItems = this.huntingSpawnItems.OrderBy(i => i.randomPercent).ToList();
    }

    private void Awake() {
        Init();
    }

    public List<ItemSpawnFarming> FarmingSpawnItemsGet() {
        var acquiredItems = new List<ItemSpawnFarming>();
        var repeat = Random.Range(1, 5);

        for (var i = 0; i < repeat; i++) {
            var pivot = Random.Range(0, 1f);
            var sum = 0f;

            foreach (var VARIABLE in this.farmingSpawnItems) {
                sum += VARIABLE.randomWeight;

                if (sum >= pivot) {
                    acquiredItems.Add(VARIABLE);
                    
                    break;
                }
            }
        }
        
        return acquiredItems;
    }

    public List<ItemSpawnHunting> HuntingSpawnItemsGet() {
        var acquiredItems = new List<ItemSpawnHunting>();
        var repeat = Random.Range(1, 3);
        
        for (var i = 0; i < repeat; i++) {
            var pivot = Random.Range(0, 1f);
            var sum = 0f;

            foreach (var VARIABLE in this.huntingSpawnItems) {
                sum += VARIABLE.randomWeight;

                if (sum >= pivot) {
                    acquiredItems.Add(VARIABLE);

                    break;
                }
            }
        }

        foreach (var VARIABLE in acquiredItems) {
            Debug.Log("ItemManager: " + VARIABLE.ItemName);
        }
        
        return acquiredItems;
    }
}