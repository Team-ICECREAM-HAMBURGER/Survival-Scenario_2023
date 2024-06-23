using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectHunger : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "기아";
    public int Term { get; } = 1;

    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.HUNGER;
    [field: SerializeField] public GameControlDictionary.RequireStatus StatusReducePercents { get; private set; }
    
    [SerializeField] private string panelText;

    public static UnityEvent OnStatusEffectAdd;
    public static UnityEvent OnStatusEffectRemove;

    
    public void Init() {
        OnStatusEffectAdd = new();
        OnStatusEffectRemove = new();
        
        OnStatusEffectAdd.AddListener(StatusEffectAdd);
        OnStatusEffectRemove.AddListener(StatusEffectRemove);
        
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }

    private void StatusEffectAdd() {
        Player.Instance.StatusEffectAdd(this);
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }

    public void StatusEffect(int value) {
        Player.Instance.StatusUpdate(this.StatusReducePercents, -1);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}