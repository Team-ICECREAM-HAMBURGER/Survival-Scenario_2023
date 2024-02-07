public class PlayerStatusEffectDehydration : IPlayerStatusEffect {
    public string StatusEffectName { get; }
    public StatusEffectType StatusEffectType { get; }

    public string Condition { get; private set; }


    private void Init() {
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {

    }
    
    
}