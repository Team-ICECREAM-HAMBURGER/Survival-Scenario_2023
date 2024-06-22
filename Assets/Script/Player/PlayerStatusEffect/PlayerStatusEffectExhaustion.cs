using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectExhaustion : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈진";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.EXHAUSTION;
    public int Term { get; private set; }
    
    [SerializeField] private float statusReducePercent;
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

    public void StatusEffectInvoke(int value) {
        var statusBodyHeat = Player.Instance.Status[GameControlType.Status.BODY_HEAT];
        var statusHydration = Player.Instance.Status[GameControlType.Status.HYDRATION];
        var statusCalories = Player.Instance.Status[GameControlType.Status.CALORIES];
        
        Player.Instance.StatusUpdate(GameControlType.Status.BODY_HEAT, statusBodyHeat * -this.statusReducePercent * 0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.HYDRATION, statusHydration * -this.statusReducePercent * 0.01f);
        Player.Instance.StatusUpdate(GameControlType.Status.CALORIES, statusCalories * -this.statusReducePercent * 0.01f);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this); 
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}