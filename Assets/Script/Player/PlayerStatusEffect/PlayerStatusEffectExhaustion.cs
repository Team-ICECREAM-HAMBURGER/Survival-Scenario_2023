using UnityEngine;

public class PlayerStatusEffectExhaustion : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈진";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.EXHAUSTION;
    public int Term { get; private set; }
    
    [SerializeField] private float statusReducePercent;

    
    public void Init() {
        this.Term = Player.Instance.StatusEffect[this.Type];
    }

    public void StatusEffectActive() {
        var statusBodyHeat = Player.Instance.Status[GameControlType.Status.BODY_HEAT];
        var statusHydration = Player.Instance.Status[GameControlType.Status.HYDRATION];
        var statusCalories = Player.Instance.Status[GameControlType.Status.CALORIES];
        
        Player.Instance.StatusUpdate(GameControlType.Status.BODY_HEAT, statusBodyHeat * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.HYDRATION, statusHydration * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.CALORIES, statusCalories * this.statusReducePercent * -0.01f);
    }
}