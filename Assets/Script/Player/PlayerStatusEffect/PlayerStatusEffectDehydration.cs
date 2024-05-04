using UnityEngine;

public class PlayerStatusEffectDehydration : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈수";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.DEHYDRATION;
    public int Term { get; set; }

    [SerializeField] private float statusReducePercent;

    
    public void Active() { // 신규, 새로운 상태 이상이 발동
        this.Term = 1;
        Player.Instance.StatusEffectAdd(this);
    }

    public void Invoke(int value) { // 갱신, 이미 적용된 상태를 업데이트
        var status = Player.Instance.Status[GameControlType.Status.HYDRATION];
        
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * statusReducePercent * -0.01f);

        if (Player.Instance.Status[GameControlType.Status.HYDRATION] > Player.Instance.StatusMap[GameControlType.Status.HYDRATION].LimitValue) {
            Player.Instance.StatusEffectRemove(this);
        }
    }
}