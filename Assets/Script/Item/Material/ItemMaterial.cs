using System;
using UnityEngine;

public class ItemMaterial : MonoBehaviour, IItemMaterial {
    [field: SerializeField] public GameTypeItem ItemType { get; private set; }
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    public float RandomWeight { get; set; }
    
    
    public void Init(float randomWeight) {
        this.RandomWeight = randomWeight;
    }
}