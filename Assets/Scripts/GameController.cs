using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameController : MonoBehaviour {
    protected Button Button;

    protected abstract void Init();
}