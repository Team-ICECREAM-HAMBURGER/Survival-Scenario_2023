using UnityEngine;

public abstract class PlayerStatusEffect : MonoBehaviour {
    protected string Name { get; set; }
    protected int Term { get; set; }
    protected GameControlType.StatusEffect Type { get; set; }
    [field: SerializeField] public GameControlDictionary.RequireStatus StatusReducePercents { get; set; }


    public virtual void Init() {
        if (Player.Instance.StatusEffect.ContainsKey(this.Type)) {
            this.Term = Player.Instance.StatusEffect[this.Type];
            GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
            PlayerStatusEffectManager.Instance.OnStatusEffect.AddListener(PlayerStatusEffectManager.Instance.StatusEffects[this.Type].StatusEffect);
        }
    }
    public abstract void StatusEffectAdd();
    public abstract void StatusEffect(int value);
    public abstract void StatusEffectRemove();
}