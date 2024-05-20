using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlCanvas : MonoBehaviour {
    public void OnCanvasActive(Canvas target) {
        target.enabled = true;
    }

    public void OnCanvasDeActive(Canvas target) {
        target.enabled = false;
    }
}