public interface IGameRandomEvent {
    float Weight { get; }
    void Event();
    (string, string) EventResult();
}