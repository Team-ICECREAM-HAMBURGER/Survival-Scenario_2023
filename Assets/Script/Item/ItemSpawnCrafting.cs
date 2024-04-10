using UnityEngine;

public class ItemSpawnCrafting : MonoBehaviour, IItem {
    [field: SerializeField] public GameTypeItem ItemType { get; set; }
    [field: SerializeField] public string ItemName { get; set; }

}