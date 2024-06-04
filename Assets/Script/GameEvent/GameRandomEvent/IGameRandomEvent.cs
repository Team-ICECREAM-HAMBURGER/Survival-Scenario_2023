public interface IGameRandomEvent {
    float Percent { get; }
    void Event();
    (string, string) EventResult();
}