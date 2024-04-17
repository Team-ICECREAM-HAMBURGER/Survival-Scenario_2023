using UnityEngine;

public class ItemCraft : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item ItemType { get; set; }
    [field: SerializeField] public string ItemName { get; set; }

    public SerializableDictionary<string, int> blueprint;
}