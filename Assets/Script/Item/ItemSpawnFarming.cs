using UnityEngine;

public class ItemSpawnFarming : MonoBehaviour, IItem {
    [field: SerializeField] public GameTypeItem ItemType { get; set; }
    [field: SerializeField] public string ItemName { get; set; }

    public float randomPercent;
    public float randomWeight;
}