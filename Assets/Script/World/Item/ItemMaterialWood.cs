using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaterialWood : ItemMaterial {
    public override void ItemUse() {
        Debug.Log(this.Name + this.Content);
    }

    public override void ItemDrop() {
    }
}
