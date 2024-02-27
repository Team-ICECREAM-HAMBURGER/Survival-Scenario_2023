using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour {
    [SerializeField] private List<GameObject> consumableItemPrefabs;
    [SerializeField] private List<GameObject> gearItemPrefabs;
    [SerializeField] private List<GameObject> materialItemPrefabs;
    [SerializeField] private List<GameObject> toolItemPrefabs;
    [SerializeField] private List<GameObject> weaponItemPrefabs;
    
    private List<IItemConsumable> consumableItems;
    private List<IItemGear> gearItems;
    private List<IItemMaterial> materialItems;
    private List<IItemTool> toolItems;
    private List<IItemWeapon> weaponItems;

    public delegate List<IItem> ItemGetEventHandler();
    public static ItemGetEventHandler OnConsumableItemGet;
    public static ItemGetEventHandler OnGearItemGet;
    public static ItemGetEventHandler OnMaterialItemGet;
    public static ItemGetEventHandler OnToolItemGet;
    public static ItemGetEventHandler OnWeaponItemGet;
    

    private void Init() {
        var sum = 0f;
        
        this.consumableItems = new();
        this.gearItems = new();
        this.materialItems = new();
        this.toolItems = new();
        this.weaponItems = new();
        
        // Material List Init();
        foreach (var VARIABLE in this.materialItemPrefabs) {
            var i = VARIABLE.GetComponent<IItemMaterial>();
            
            sum += i.RandomPercent;
            this.materialItems.Add(i);
        }

        foreach (var VARIABLE in this.materialItems) {
            VARIABLE.Init(VARIABLE.RandomPercent / sum);
        }

        this.materialItems = this.materialItems.OrderBy(i => i.RandomWeight).ToList();
        
        OnMaterialItemGet += MaterialItemGet;
    }

    private void Awake() {
        Init();
    }
    
    private List<IItem> MaterialItemGet() {
        var repeat = Random.Range(1, 5);
        var acquiredItems = new List<IItem>();
        
        for (var i = 0; i < repeat; i++) {
            var pivot = Random.Range(0, 1f);
            var sum = 0f;
            
            foreach (var VARIABLE in this.materialItems) {
                sum += VARIABLE.RandomWeight;
                
                if (sum >= pivot) {
                    acquiredItems.Add(VARIABLE);
                    Debug.Log("Add! " + VARIABLE.ItemName);
                    
                    break;
                }
            }
        }

        return acquiredItems;
    }
}