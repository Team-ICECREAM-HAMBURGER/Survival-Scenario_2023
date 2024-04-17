using UnityEngine;

public class PlayerStatusEffectInjured : MonoBehaviour, IPlayerStatusEffect {
    public string StatusEffectName { get; } = "부상";
    public GameControlType.StatusEffect StatusEffectType { get; } = GameControlType.StatusEffect.INJURED;
    public int DurationTerm { get; private set; }

    public delegate void InjuredEffectEventHandler();
    public static InjuredEffectEventHandler OnInjuredEffectEvent;

    
    private void Init() {
        OnInjuredEffectEvent += Event;
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        // TODO: 일정 시간동안 상태가 유지되어야 함. (일정 시간은 무작위 범위) -> 상태 수치 감소량이 증가함. -> 이동 불가
        // TODO: 약초로 만든 의약품을 사용하면 일정 시간이 줄어들어야 함. (줄어드는 양은 고정적)
        
        // GameInfoControl.OnTimeUpdateEvent += DurationTermUpdate;
        //
        // this.DurationTerm = Random.Range(3, 8) * 500;
        // Player.Instance.information.status[GameTypeStatus.STAMINA].StatusDecreaseMultiplier = 2f;
        //
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
    
    private void DurationTermUpdate(int value) {
        if (this.DurationTerm > 0) {
            this.DurationTerm -= value;
            
            return;
        }
        
        // Player.Instance.StatusEffectRemove(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorUpdateEvent();
    }
}