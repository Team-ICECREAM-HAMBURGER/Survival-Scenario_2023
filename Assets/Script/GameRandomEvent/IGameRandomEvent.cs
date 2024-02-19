public interface IGameRandomEvent {
    float Weight { get; }
    (string title, string content) Event();
    (string title, string content) Result();
}