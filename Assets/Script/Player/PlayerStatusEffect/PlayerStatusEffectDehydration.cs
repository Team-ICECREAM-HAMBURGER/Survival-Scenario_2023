using UnityEngine;

public class PlayerStatusEffectDehydration : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈수";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.DEHYDRATION;
    public int Term { get; private set; } = 1;

    [SerializeField] private float statusReducePercent;

    
    public void Init(int term) {
        this.Term = term;
    }

    public void Invoke() {
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * statusReducePercent * -0.01f);
    }
}