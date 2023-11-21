using UnityEngine;

public class GameItemWood : MonoBehaviour, IGameItem {
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }
    
    
    public GameItemWood(float weight) {
        this.Weight = weight;
        this.ItemType = ItemType.WOOD;
    }
}