using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerSearchResultView : MonoBehaviour {
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;
    
    public delegate void SearchResultUIUpdateHandler(string value);
    public static SearchResultUIUpdateHandler OnSearchResultUIInjured;
    public static SearchResultUIUpdateHandler OnSearchResultUIFarming;
    public static SearchResultUIUpdateHandler OnSearchResultUIHunting;
    public static SearchResultUIUpdateHandler OnSearchResultUIInDanger;
    
    
    private void Init() {
        OnSearchResultUIInjured += Injured;
        OnSearchResultUIFarming += Farming;
        OnSearchResultUIHunting += Hunting;
        OnSearchResultUIInDanger += InDanger;
    }

    private void Awake() {
        Init();
    }

    private void Farming(string value) {
        this.titleText.text = "쓸만한 것들을 찾았다.";
        this.contentText.text = value;
    }

    private void Hunting(string value) {
        this.titleText.text = "주변을 탐색하던 도중, 사냥감을 발견했다.";
        this.contentText.text = value;
    }
    
    private void Injured(string value) {
        this.titleText.text = "주변을 탐색하던 도중, 발을 헛딛어 큰 부상을 입었다.";
        this.contentText.text = value;
    }

    private void InDanger(string value) {
        this.titleText.text = "맹수의 추격에서 가까스로 도망쳤다.";
        this.contentText.text = value;
    }
}