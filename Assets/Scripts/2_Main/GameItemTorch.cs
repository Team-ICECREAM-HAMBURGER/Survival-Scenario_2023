using UnityEngine;

public class GameItemTorch : MonoBehaviour, IGameItem {
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }
    
    
    public GameItemTorch(float weight) {
        this.Weight = weight;
        this.ItemType = ItemType.TORCH;
    }
}