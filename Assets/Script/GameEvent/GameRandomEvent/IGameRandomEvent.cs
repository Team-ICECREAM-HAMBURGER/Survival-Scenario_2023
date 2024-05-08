public interface IGameRandomEvent {
    float Weight { get; }
    (string, string) Event();
    void EventResult();
}