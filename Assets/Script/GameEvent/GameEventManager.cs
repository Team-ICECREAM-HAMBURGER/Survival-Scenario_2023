public class GameEventManager : GameControlSingleton<GameEventManager> {
    public void GameOverBadEnding((string, string) value) {
        GameEventGameOver.OnBadEnding.Invoke(value.Item1, value.Item2);
    }
    
    public void GameReset() {
        GameInformationManager.Instance.GameDataUpdate(GameControlType.GameSaveType.DATA_DELETE);
    }
}