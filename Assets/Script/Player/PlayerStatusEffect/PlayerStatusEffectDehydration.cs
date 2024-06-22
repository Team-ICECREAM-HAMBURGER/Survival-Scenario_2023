using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectDehydration : MonoBehaviour, IPlayerStatusEffect {
    public string Name { get; } = "탈수";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.DEHYDRATION;
    public int Term { get; private set; } = 1;

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
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * -this.statusReducePercent * 0.01f);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}