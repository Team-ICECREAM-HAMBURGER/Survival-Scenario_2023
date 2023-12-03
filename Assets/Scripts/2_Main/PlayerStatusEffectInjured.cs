using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : PlayerStatusEffect {
    public override int Duration { get; } = (Random.Range(3, 8) * 500);
    public override string StatusEffectName { get; } = "부상";
    public override statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;


    public PlayerStatusEffectInjured() {
        StatusEffect();
    }
    
    public override void StatusEffect() {
        // TODO: Duration -> 소모되는 상태 수치량이 1.5배 증가
        Player.instance.StatusMultiplier = 1.5f;
    }
}