using UnityEngine;

public class ItemFoodBerry : Item {
    public override void ItemUse(int value) {
        this.OnPlayerStatusUpdate.Invoke();
        base.ItemUse(value);
    }
}