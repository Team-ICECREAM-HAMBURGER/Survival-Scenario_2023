using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectInjured : MonoBehaviour, IPlayerStatusEffect {   // Presenter
    public string Name { get; } = "부상";
    public GameControlType.StatusEffect Type { get; } = GameControlType.StatusEffect.INJURED;
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
        
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }

    private void StatusEffectAdd() {
        Player.Instance.StatusEffectAdd(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
    
    public void StatusEffectUpdate() {
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];
        
        this.Term -= World.Instance.SpentTerm;
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * this.statusReducePercent * -0.01f);

        if (this.Term <= 0) {
            Player.Instance.StatusEffectRemove(this);
        }
        
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}