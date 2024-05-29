using TMPro;
using UnityEngine;

public interface IItem {
    public GameControlType.Item Type { get; }
    public string Name { get; }
    public string Content { get; }
    
    public float RandomPercent { get; }
    public float RandomWeight { get; }
    public int RandomMaxValue { get; }

    public TMP_Text InventoryNameText { get; }
    public TMP_Text InventoryCountText { get; }

    public void Init(float value, Transform content);
    public void InventoryCountUpdate(int value);
}