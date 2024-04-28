public class StatusEffectManager : GameControlSingleton<StatusEffectManager> {
    private IStatusEffectCommand statusEffectCommand;
    
    
    public void Execute(IStatusEffectCommand command) {
        this.statusEffectCommand = command;
        this.statusEffectCommand.Execute();
    }
}