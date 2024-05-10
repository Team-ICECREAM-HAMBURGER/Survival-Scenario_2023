using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectDehydration : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈수";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.DEHYDRATION;
    public int Term { get; private set; } = 1;

    [SerializeField] private float statusReducePercent;
    
    public static UnityEvent OnStatusEffectAdd;
    public static UnityEvent OnStatusEffectRemove;

    
    public void Init() {
        OnStatusEffectAdd = new();
        OnStatusEffectRemove = new();
        
        OnStatusEffectAdd.AddListener(StatusEffectAdd);
        OnStatusEffectRemove.AddListener(StatusEffectRemove);
    }

    private void StatusEffectAdd() {
        Player.Instance.StatusEffectAdd(this);
    }

    public void StatusEffectUpdate() {
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * statusReducePercent * -0.01f);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
    }
}