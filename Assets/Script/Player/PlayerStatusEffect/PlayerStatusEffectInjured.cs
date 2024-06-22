using System.Text;
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

        if (Player.Instance.StatusEffect.ContainsKey(this.Type)) {
            this.Term = Player.Instance.StatusEffect[this.Type];
            PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, $"{this.panelText} ({this.Term}텀)");    
        }
    }

    private void StatusEffectAdd() {
        var value = Random.Range(1, 5) * 500;
        
        if (this.Term < value) {
            this.Term = value;
        }
        else {
            this.Term += value;
        }
        
        Player.Instance.StatusEffectAdd(this);
        
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, $"{this.panelText} ({this.Term}텀)");
    }
    
    public void StatusEffectInvoke(int value) {
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];

        this.Term -= value;
        
        Player.Instance.StatusEffectUpdate(this);
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * -this.statusReducePercent * 0.01f);
        
        if (this.Term <= 0) {
            Player.Instance.StatusEffectRemove(this);
        }
        
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, $"{this.panelText} ({this.Term}텀)");
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}