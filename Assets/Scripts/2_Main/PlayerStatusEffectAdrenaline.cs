public class PlayerStatusEffectAdrenaline : PlayerStatusEffect {
    public override int Duration { get; set; } = 50;
    public override string StatusEffectName { get; } = "체력 증진";
    public override statusEffectType StatusEffectType { get; } = statusEffectType.ADRENALINE;
    
    
    public PlayerStatusEffectAdrenaline() {
        StatusEffect();
    }
    
    public override void StatusEffect() {
        // TODO: 어떠한 행동을 취해도 체력을 소모하지 않음.
        // 조건: 100일동안 부정적 상태 이상이 한 번도 일어나지 않았으며, 모든 상태 수치가 80% 이상일 경우. 부정적 상태이상이 없어야 함.
        
    }
}