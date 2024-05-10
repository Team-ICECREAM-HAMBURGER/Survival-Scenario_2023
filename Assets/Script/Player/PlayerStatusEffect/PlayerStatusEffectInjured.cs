using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectInjured : MonoBehaviour, IPlayerStatusEffect {   // Presenter
    public string Name { get; } = "부상";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.INJURED;
    public int Term { get; private set; }

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
        
        this.Term -= TimeManager.Instance.SpentTerm;
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * this.statusReducePercent * -0.01f);

        if (this.Term <= 0) {
            Player.Instance.StatusEffectRemove(this);
        }
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
    }
}