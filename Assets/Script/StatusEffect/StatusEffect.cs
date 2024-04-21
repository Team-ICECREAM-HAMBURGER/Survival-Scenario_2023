public class StatusEffect {
    public string name;
    public GameControlType.StatusEffect type;
    public int durationTerm;

    public void Event(StatusEffect effect) {
        Player.Instance.StatusEffectUpdate(effect);
    }
}