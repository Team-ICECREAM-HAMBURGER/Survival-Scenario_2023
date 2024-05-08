using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagerIntro : MonoBehaviour {
    public void Resume() {
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