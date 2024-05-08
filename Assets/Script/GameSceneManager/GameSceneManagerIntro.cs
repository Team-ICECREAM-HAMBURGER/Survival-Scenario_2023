using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagerIntro : MonoBehaviour {
    public void Resume() {
        if (GameInformationManager.Instance.playerInformation is null) {
            Debug.Log("XX");
            return;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }

    public void NewGame() {
        
    }

    public void Option() {
        
    }

    public void Credit() {
        
    }

    public void Quit() {
        
    }
}