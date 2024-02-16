using UnityEngine;

public class PlayerBehaviourMove : MonoBehaviour, IPlayerBehaviour {
    private float requireStatusValue;
    
    
    private void Init() {
        this.requireStatusValue = 50f;
    }

    private void Awake() {
        Init();
    }

    public bool CanBehaviour() {
        if (Player.Instance.StatusEffectCheck(GameTypeStatusEffect.INJURED)) {
            PlayerBehaviourMovePresenter.OnMessageInjuredEvent();
            
            return false;
        }
        
        if (!Player.Instance.StatusCheck(this.requireStatusValue)) {
            PlayerBehaviourMovePresenter.OnMessageLowStatusEvent();
            
            return false;
        }

        return true;
    }
    
    public void Behaviour() {
        Player.Instance.StatusDecrease(25f);
    }
}