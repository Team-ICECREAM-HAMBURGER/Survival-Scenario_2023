using UnityEngine;

public class StatusEffectManager : MonoBehaviour {
    public delegate void StatusEffectEventHandler();
    public static StatusEffectEventHandler OnInjuredEffectEvent;
}