using UnityEngine;

public abstract class PlayerStatusEffect : MonoBehaviour {
    public string Name { get; set; }
    public int Term { get; set; }
    public GameControlType.StatusEffect Type { get; set; }
    [field: SerializeField] public GameControlDictionary.RequireStatus StatusReducePercents { get; set; }
    
    
    public abstract void Init();
    public abstract void StatusEffectAdd();
    public abstract void StatusEffect();
    public abstract void StatusEffectRemove();
}