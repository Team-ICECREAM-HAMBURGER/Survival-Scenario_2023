using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemSpawnManager : MonoBehaviour {
    private List<IItemConsumable> consumableItems;
    private List<IItemGear> gearItems;
    private List<IItemMaterial> materialItems;
    private List<IItemTool> toolItems;
    private List<IItemWeapon> weaponItems;

    
    public delegate void MaterialItemRandomGetEventHandler();
    public static MaterialItemRandomGetEventHandler OnMaterialItemRandomGet;
    

    private void Init() {
        this.materialItems = gameObject.GetComponents<IItemMaterial>().ToList();
        
        MaterialItemListSort();
        OnMaterialItemRandomGet += MaterialItemSpawn;
    }

    private void Awake() {
        Init();
    }

    private void MaterialItemListSort() {
        var sum = 0f;

        foreach (var VARIABLE in this.materialItems) {
            sum += VARIABLE.RandomWeight;
        }

        foreach (var VARIABLE in this.materialItems) {
            VARIABLE.RandomWeight /= sum;
        }
        
        this.materialItems = this.materialItems.OrderBy(i => i.RandomWeight).ToList();
    }
    
    private void MaterialItemSpawn() {
        var repeat = Random.Range(1, 5);
        var items = new HashSet<IItem>();
        
        for (var i = 0; i < repeat; i++) {
            var randomPivot = Random.Range(0f, 1f);
            var sum = 0f;
        
            foreach (var VARIABLE in this.materialItems) {
                sum += VARIABLE.RandomWeight;

                if (sum >= randomPivot) {
                    Debug.Log(VARIABLE.ItemName);
                    VARIABLE.ItemQuantity += 1;
                    items.Add(VARIABLE);
                    break;
                }
            }
        }
        
        PlayerInventory.OnItemGet(items);
    }
}