using UnityEngine;

public class StatusEffectDehydration : MonoBehaviour, IStatusEffect {
    public string Name { get; private set; }
    public GameControlType.StatusEffect Type { get; private set; }
    public int Term { get; private set; }

    private float statusReduceMultiplier;
    
    
    public void Init() {
        this.Name = "탈수";
        this.Type = GameControlType.StatusEffect.CONDITION;
        this.Term = 1;
    }

    private void Awake() {
        Init();
    }

    public void Invoke() {  // 갱신, 이미 적용된 상태를 업데이트
        // GameDataSave();
        // Player.StatusUpdate(health, *2);
        // Player.Instance.StatusEffectUpdate(this)
    }

    public void Active() {  // 신규, 새로운 상태 이상이 발동
        // if (!TryAdd() :
        //      StatusEffect[effect.name].Value = effect.term;
    }
}