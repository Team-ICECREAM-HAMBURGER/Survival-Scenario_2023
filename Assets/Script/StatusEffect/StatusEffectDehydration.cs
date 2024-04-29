using UnityEngine;

public class StatusEffectDehydration : MonoBehaviour, IStatusEffect {
    public string Name { get; private set; }
    public GameControlType.StatusEffect Type { get; private set; }
    public int Term { get; private set; }

    private float statusReduceMultiplier;
    
    
    public void Init() {
        this.Name = "탈수";
        this.Type = GameControlType.StatusEffect.CONDITION;
        this.Term = 1;
    }

    private void Awake() {
        Init();
    }

    public void StatusEffectInvoke() {
        // GameDataSave();
        // Player.StatusUpdate(health, *2);
        // Player.Instance.StatusEffectUpdate(this)
    }

    public void StatusEffectUpdate() {
        // if (!TryAdd() :
        //      StatusEffect[effect.name].Value = effect.term;
    }
}