using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : MonoBehaviour, IPlayerStatusEffect {   // Presenter
    public string Name { get; } = "부상";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.INJURED;
    public int Term { get; private set; }

    [SerializeField] private float statusReducePercent;
    

    public void Init(int term) {
        this.Term = term;
    }
    
    public void Invoke() {
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        this.Term -= TimeManager.Instance.SpentTerm;
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * this.statusReducePercent * -0.01f);

        if (this.Term <= 0) {
            Player.Instance.StatusEffectRemove(this);
        }
    }
}