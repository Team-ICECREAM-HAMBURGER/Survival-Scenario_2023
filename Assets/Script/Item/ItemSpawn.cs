using UnityEngine;

public class ItemSpawn : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item ItemType { get; set; }
    [field: SerializeField] public string ItemName { get; set; }
    
    public float randomPercent;
    public float randomWeight;
}