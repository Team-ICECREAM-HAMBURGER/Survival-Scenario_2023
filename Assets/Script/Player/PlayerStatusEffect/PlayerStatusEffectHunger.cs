using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectHunger : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "기아";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.HUNGER;
    public int Term { get; set; }
    
    [SerializeField] private float statusReducePercent;
    [SerializeField] private string panelText;

    public static UnityEvent OnStatusEffectAdd;
    public static UnityEvent OnStatusEffectRemove;

    
    public void Init() {
        OnStatusEffectAdd = new();
        OnStatusEffectRemove = new();
        
        OnStatusEffectAdd.AddListener(StatusEffectAdd);
        OnStatusEffectRemove.AddListener(StatusEffectRemove);
        
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }

    private void StatusEffectAdd() {
        Player.Instance.StatusEffectAdd(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }

    public void StatusEffectUpdate() {
        var statusCalories = Player.Instance.Status[GameControlType.Status.CALORIES];
        var statusStamina = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.CALORIES, statusCalories * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, statusStamina * this.statusReducePercent * -0.01f);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}