public class StatusEffectInjuredCommand : IStatusEffectCommand {
    private StatusEffectInjured effect;

    
    public StatusEffectInjuredCommand(StatusEffectInjured effect) {
        this.effect = effect;
    }
    
    public void Execute() {
        this.effect.Effect();
    }
}