using UnityEngine;
using Random = UnityEngine.Random;

public class StatusEffectInjured : MonoBehaviour, IStatusEffect {
    public string Name { get; } = "부상";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.DURATION;
    public int Term { get; set; }

    [SerializeField] private float statusReducePercent;
    

    public void Invoke() {  // 갱신, 이미 적용된 상태를 업데이트
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, -status * statusReducePercent);
        
        GameInformation.OnPlayerGameDataSave();
        GameInformation.OnWorldGameDataSave();
    }

    public void Active() {  // 신규, 새로운 상태 이상이 발동
        this.Term = Random.Range(1, 5) * 500;
        Player.Instance.StatusEffectUpdate(this);
        Invoke();
    }
}