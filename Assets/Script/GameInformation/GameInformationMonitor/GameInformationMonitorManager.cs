public class GameInformationMonitorManager : GameControlSingleton<GameInformationMonitorManager> {
    // GameInformationMonitor -> GameInformationMonitorManager -> (OUT) //
    
    
    
    
    // GameInformationMonitor <- GameInformationMonitorManager <- (OUT) //
    public void CurrentLocationUpdate(string value) {
        GameInformationMonitorWorld.OnCurrentLocationUpdate.Invoke(value);
    }
}