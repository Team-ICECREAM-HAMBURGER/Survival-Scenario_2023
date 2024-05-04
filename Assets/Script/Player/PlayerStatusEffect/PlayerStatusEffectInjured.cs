using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : MonoBehaviour, IPlayerStatusEffect {   // Presenter
    public string Name { get; } = "부상";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.INJURED;
    public int Term { get; set; }

    [SerializeField] private float statusReducePercent;
    

    public void Active() {  // 신규, 새로운 상태 이상이 발동
        this.Term = Random.Range(1, 5) * 500;
        Player.Instance.StatusEffectAdd(this);
    }
    
    public void Invoke(int value) {  // 갱신, 이미 적용된 상태를 업데이트
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * statusReducePercent * -0.01f);
        this.Term += value;
        
        if (this.Term <= 0) {
            Player.Instance.StatusEffectRemove(this);
        }
        else {
            Player.Instance.StatusEffectUpdate(this);
        }
    }
}