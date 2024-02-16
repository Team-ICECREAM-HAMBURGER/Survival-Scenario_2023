using System.Text;
using UnityEngine;

public class PlayerBehaviourMovePresenter : MonoBehaviour {
    private string messageTitle;
    private StringBuilder messageContent;
    
    public delegate void OnMessageHandler();
    public static OnMessageHandler OnMessageInjuredEvent;
    public static OnMessageHandler OnMessageLowStatusEvent;
    public static OnMessageHandler OnMessageMovedEvent;
    

    private void Init() {
        this.messageContent = new StringBuilder();
        
        OnMessageInjuredEvent += MessageInjured;
        OnMessageLowStatusEvent += MessageLowStatus;
        OnMessageMovedEvent += MessageMoved;
    }

    private void Awake() {
        Init();
    }
    
    private void MessageInjured() {
        this.messageContent.Clear();
        
        this.messageTitle = "부상을 입음";
        this.messageContent.Append("부상을 입은 상태에서는 다른 지역으로 이동할 수 없다.\n");
        this.messageContent.Append("부상을 회복하기 위해서는 휴식과 잠이 중요하다.\n");
        this.messageContent.Append("만약 의료품이 있다면 더욱 빠르게 회복이 가능하다.\n");

        PlayerBehaviourMoveView.OnMessageWarningEvent(this.messageTitle, this.messageContent.ToString());
    }

    private void MessageLowStatus() {
        this.messageContent.Clear();

        this.messageTitle = "스테이터스가 너무 낮음";
        this.messageContent.Append("다른 지역으로 이동할 수 있을만큼 스테이터스가 충분하지 않다.\n");
        this.messageContent.Append("스테이터스는 음식, 물, 휴식 등으로 회복할 수 있다.\n");
        this.messageContent.Append("\n");
        this.messageContent.Append("- 스테이터스 요구 사항\n");
        this.messageContent.Append($"체력: {80}% 이상\n");
        this.messageContent.Append($"체온: {50}% 이상\n");
        this.messageContent.Append($"수분: {60}% 이상\n");
        this.messageContent.Append($"허기: {70}% 이상\n");
        
        PlayerBehaviourMoveView.OnMessageWarningEvent(this.messageTitle, this.messageContent.ToString());
    }

    private void MessageMoved() {
        this.messageContent.Clear();

        this.messageTitle = "결과";
        this.messageContent.Append("\n");

        PlayerBehaviourMoveView.OnMessageResultEvent(this.messageTitle, this.messageContent.ToString());
    }
}