using System.Collections.Generic;
using UnityEngine;

public class ItemFoodBerry : Item {
    [Space(25f)]
    
    [Header("Status Update Value")]
    [SerializeField] private float staminaValue;
    [SerializeField] private float hydrationValue;
    [SerializeField] private float caloriesValue;

    private List<(GameControlType.Status, float)> itemEffectStatusValue;


    public override void Init() {
        base.Init();
        
        this.itemEffectStatusValue = new() {
            (GameControlType.Status.STAMINA, this.staminaValue),
            (GameControlType.Status.HYDRATION, this.hydrationValue),
            (GameControlType.Status.CALORIES, this.caloriesValue)
        };
    }

    public override void ItemUse(int value) {
        base.ItemUse(value);
        
        ItemManager.Instance.ItemEffectStatusUpdate(this.itemEffectStatusValue);
        ItemManager.Instance.InventorySync();
    }
}