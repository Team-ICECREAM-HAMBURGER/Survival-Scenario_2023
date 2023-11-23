using UnityEngine;
using Random = UnityEngine.Random;

public class ItemWood : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public ItemType ItemType { get; set; }

    
    public ItemWood(float weight = 0f, int count = 0, bool isAcquirable = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsAcquirable = isAcquirable;
        this.ItemType = ItemType.WOOD;
    }

    public void ItemFarming() { // TODO: 탐색하기 파밍 이벤트 결과 (수집 가능 아이템)
    }
}