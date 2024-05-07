using UnityEngine;

public class PlayerStatusEffectColdness : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "추위";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.COLDNESS;
    public int Term { get; set; }

    [SerializeField] private float statusReducePercent;


    public void Init(int term) {
        this.Term = term;
    }
    
    public void Active() { // 신규, 새로운 상태 이상이 발동
        this.Term = 1;
        Player.Instance.StatusEffectAdd(this);
    }

    public void Invoke() { // 갱신, 이미 적용된 상태를 업데이트
        // var statusBodyHeat = Player.Instance.Status[GameControlType.Status.BODY_HEAT];
        // var statusStamina = Player.Instance.Status[GameControlType.Status.STAMINA];
        //
        // Player.Instance.StatusUpdate(GameControlType.Status.BODY_HEAT, statusBodyHeat * this.statusReducePercent * -0.01f);
        // Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, statusStamina * this.statusReducePercent * -0.01f);
        //
        // if (Player.Instance.Status[GameControlType.Status.BODY_HEAT] >
        //     Player.Instance.StatusMap[GameControlType.Status.BODY_HEAT].LimitValue) {
        //     Player.Instance.StatusEffectRemove(this);
        // }
    }
}