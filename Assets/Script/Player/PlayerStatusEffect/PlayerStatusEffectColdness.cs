using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectColdness : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "저채온증";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.COLDNESS;
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
    
    public void StatusEffectInvoke(int value) {
        var statusBodyHeat = Player.Instance.Status[GameControlType.Status.BODY_HEAT];
        var statusStamina = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.BODY_HEAT, statusBodyHeat * this.statusReducePercent * -0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, statusStamina * this.statusReducePercent * -0.01f);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}