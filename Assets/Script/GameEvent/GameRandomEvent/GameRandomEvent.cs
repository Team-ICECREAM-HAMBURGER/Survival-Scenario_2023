using UnityEngine;

public abstract class GameRandomEvent : MonoBehaviour {
    public float Percent { get; protected set; }


    public abstract void Init();
    public abstract void Event();
    // public abstract (string, string) EventResult();
}