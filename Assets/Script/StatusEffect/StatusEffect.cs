public class StatusEffect {
    public string name;
    public GameControlType.StatusEffect type;
    public int durationTerm;
    
    
    public void Event(StatusEffect effect) {
        Player.Instance.StatusEffectUpdate(effect);
    }

    public void Invoke(int term) {
        this.durationTerm -= term;
    }
}