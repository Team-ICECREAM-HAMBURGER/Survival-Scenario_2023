using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMessageView : MonoBehaviour {
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;

    public delegate void GameMessageViewHandler();
    public static GameMessageViewHandler OnGameWarningMessageViewEvent;
    public static GameMessageViewHandler OnGameNoticeMessageViewEvent;
    

    private void Init() {
    }

    private void Awake() {
        Init();
    }

    private void WarningEvent() {
    }
    
    private void ReturnToMain() {
    }
}