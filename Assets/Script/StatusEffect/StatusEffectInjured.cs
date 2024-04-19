using UnityEngine;

public class StatusEffectInjured : IStatusEffect {
    public string StatusEffectName { get; } = "부상";
    public GameControlType.StatusEffect StatusEffectType { get; } = GameControlType.StatusEffect.INJURED;
    
    public int DurationTerm { get; private set; }
    public float StatusDecreaseMultiplier { get; private set; }
    public bool isActivated { get; private set; }
    
    public delegate void StatusEffectEventHandler();
    public static StatusEffectEventHandler OnInjuredEffectEvent;
    
    private void Init() {
        OnInjuredEffectEvent += Event;
        this.isActivated = false;
        this.StatusDecreaseMultiplier = 1f;
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        // TODO: 일정 시간동안 상태가 유지되어야 함. (일정 시간은 무작위 범위) -> 상태 수치 감소량이 증가함. -> 이동 불가
        // TODO: 약초로 만든 의약품을 사용하면 일정 시간이 줄어들어야 함. (줄어드는 양은 고정적)
        this.DurationTerm = Random.Range(3, 8) * 500;
        this.StatusDecreaseMultiplier = 2f;
        this.isActivated = true;
    
        // TODO: 멀티플라이어 적용 -> 스테이터스 감소 시 적용되어야 한다.
        // TODO: 텀이 감소할 때 텀이 업데이트 되어야 한다.
        //Player.Instance.StatusEffectUpdate();
        
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
    
    public void DurationTermUpdate() {
        Debug.Log("!!");
        // Player.Instance.StatusEffectRemove(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorUpdateEvent();
    }
}