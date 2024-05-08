using UnityEngine;

public class PlayerStatusEffectExhaustion : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈진";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.EXHAUSTION;
    public int Term { get; set; }
    
    [SerializeField] private float statusReducePercent;

    
    public void Init(int term) {
        this.Term = term;
    }

    public void Invoke() { // 갱신, 이미 적용된 상태를 업데이트
        var statusBodyHeat = Player.Instance.Status[GameControlType.Status.BODY_HEAT];
        var statusHydration = Player.Instance.Status[GameControlType.Status.HYDRATION];
        var statusCalories = Player.Instance.Status[GameControlType.Status.CALORIES];
        
        Player.Instance.StatusUpdate(GameControlType.Status.BODY_HEAT, statusBodyHeat * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.HYDRATION, statusHydration * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.CALORIES, statusCalories * this.statusReducePercent * -0.01f);

    }
}