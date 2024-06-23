using TMPro;
using UnityEngine;

public interface IItem {
    public GameControlType.Item ItemType { get; }
    public GameControlType.Behaviour ItemGetType { get; }
    public string Name { get; }
    public string Content { get; }
    
    public float RandomPercent { get; }
    public float RandomWeight { get; set; }
    public int RandomMaxValue { get; }

    public TMP_Text InventoryNameText { get; }
    public TMP_Text InventoryCountText { get; }

    public void Init(Transform content);
    public void InventoryCountUpdate(int value);
    public void InventoryInfoUpdate();
    public void ItemDrop();
}