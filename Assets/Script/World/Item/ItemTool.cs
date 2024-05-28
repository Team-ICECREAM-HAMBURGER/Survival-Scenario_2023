using TMPro;
using UnityEngine;

public class ItemTool : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item Type { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public string Content { get; set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    [field: SerializeField] public float RandomWeight { get; private set; }
    [field: SerializeField] public int RandomMaxValue { get; private set; }

    [Space(25f)] 
    
    [SerializeField] private TMP_Text inventoryNameText;
    [SerializeField] private TMP_Text inventoryCountText;
    
    
    public void Init(float value) {
        this.RandomWeight = (this.RandomPercent / value);
    }
}