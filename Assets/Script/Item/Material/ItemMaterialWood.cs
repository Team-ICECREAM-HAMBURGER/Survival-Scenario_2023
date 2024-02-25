using System;
using UnityEngine;

public class ItemMaterialWood : MonoBehaviour, IItemMaterial {
    [field: SerializeField] public GameTypeItem ItemType { get; private set; }
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    public float RandomWeight { get; set; }
    
    
    public void Init(float randomWeight) {
        this.ItemType = GameTypeItem.MATERIAL_WOOD;
        this.ItemName = "나무";
        this.RandomPercent = 95f;
        this.RandomWeight = randomWeight;
    }
}