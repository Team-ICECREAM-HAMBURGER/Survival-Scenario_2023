public delegate void PlayerBehaviourEventHandler();
public interface IGameRandomEvent {
    static PlayerBehaviourEventHandler OnPlayerBehaviourEvent;
    float Weight { get; set; }
    void Event();
}