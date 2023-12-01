using System;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    public abstract int Count { get; set; }
    public abstract float Weight { get; set; }
    
    public abstract string ItemName { get; }
    public abstract bool IsAcquirable { get; }
    public abstract itemType ItemType { get; }
    public abstract eventType EventType { get; }


    public virtual void ItemUse() {
        return;
    }
    
    public virtual void ItemAcquire() {
        return;
    }
}