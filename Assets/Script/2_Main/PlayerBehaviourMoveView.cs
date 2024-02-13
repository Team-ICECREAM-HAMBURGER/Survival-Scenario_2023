using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourMoveView : MonoBehaviour {
    [Header("Loading Screen")]
    [SerializeField] private GameObject moveLoadingScreen;

    [Space(10f)]
    
    [Header("UI Buttons")]
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    [Space(10f)]
    
    [Header("Behaviour Result Screen")]
    [SerializeField] private GameObject moveResultScreen;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;

    public delegate void OnResultMessageUpdateHandler(string title, string content);
    public static OnResultMessageUpdateHandler OnMessageUpdateEvent;


    private void Init() {
        OnMessageUpdateEvent += ResultMessageUpdate;
    }

    private void Awake() {
        Init();
    }

    private void ResultMessageUpdate(string title, string content) {
        
    }
}