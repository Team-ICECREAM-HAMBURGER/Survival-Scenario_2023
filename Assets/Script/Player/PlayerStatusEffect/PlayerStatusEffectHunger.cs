using UnityEngine;

public class PlayerStatusEffectHunger : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "기아";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.HUNGER;
    public int Term { get; set; }
    
    [SerializeField] private float statusReducePercent;

    
    public void Init(int term) {
        this.Term = term;
    }


    public void Invoke() {
        var statusCalories = Player.Instance.Status[GameControlType.Status.CALORIES];
        var statusStamina = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.CALORIES, statusCalories * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, statusStamina * this.statusReducePercent * -0.01f);
    }
}