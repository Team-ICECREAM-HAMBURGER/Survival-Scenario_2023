using UnityEngine;

public class GameItemFireTool : MonoBehaviour, IGameItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }

    public GameItemFireTool(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.FIRE_TOOL;
    }
}