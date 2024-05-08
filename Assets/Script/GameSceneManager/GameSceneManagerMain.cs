using UnityEngine;

public class GameSceneManagerMain : MonoBehaviour {
    [SerializeField] private Canvas fromCanvas;
    [SerializeField] private Canvas toCanvas;


    public void OnCanvasChange() {
        this.fromCanvas.enabled = false;
        this.toCanvas.enabled = true;
    }

    public void OnCanvasEnable(Canvas canvas) {
        canvas.enabled = true;
    }

    public void OnCanvasDisable(Canvas canvas) {
        canvas.enabled = false;
    }
}