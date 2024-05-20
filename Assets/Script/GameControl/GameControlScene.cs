using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScene : MonoBehaviour {
    public void OnSceneChange(int scene) {
        SceneManager.LoadScene(scene);
    }
}
