public class StatusEffectDehydration : StatusEffect {
    public StatusEffectDehydration() {
        this.name = "탈수";
        this.type = GameControlType.StatusEffect.CONDITION;
        this.term = 1;
    }
}