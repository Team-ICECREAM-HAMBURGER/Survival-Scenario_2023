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
            this.panelText += " " + this.Term + "텀";        // TODO: 갱신을 할 때마다 문자열이 계속 길어지는 중; 텀 업데이트 수정 필요
            PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
        }
    }

    private void StatusEffectAdd() {
        this.Term = Random.Range(1, 5) * 500;
        this.panelText += " " + this.Term + "텀";
        Player.Instance.StatusEffectAdd(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
    
    public void StatusEffectUpdate(int value) {
        var status = Player.Instance.Status[GameControlType.Status.STAMINA];

        this.Term -= value;
        Player.Instance.StatusUpdate(GameControlType.Status.STAMINA, status * this.statusReducePercent * -0.01f);
        
        if (this.Term <= 0) {
            Player.Instance.StatusEffectRemove(this);
        }
        
        this.panelText += " " + this.Term + "텀";
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
    
    private void StatusEffectRemove() {
        Player.Instance.StatusEffectRemove(this);
        PlayerInformationViewer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.panelText);
    }
}