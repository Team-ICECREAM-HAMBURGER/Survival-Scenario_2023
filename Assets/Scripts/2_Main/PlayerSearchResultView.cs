using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSearchResultView : MonoBehaviour {
    public static PlayerSearchResultView Instance;

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;

    private string content = "";
    
    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;
    }

    private void Awake() {
        Init();
    }

    public void Farming(Dictionary<string, int> acquiredItems) {
        this.content = "";

        this.titleText.text = "쓸만한 것들을 찾았다.";
        
        foreach (var VARIABLE in acquiredItems) {
            this.content += "- " + VARIABLE.Key + " " + VARIABLE.Value.ToString("+#;-#;0") + "\n";
        }
        
        this.contentText.text = this.content;
    }

    public void Hunting([CanBeNull] Dictionary<string, int> resultItems) {
        this.content = "";

        if (resultItems is null) {
            this.titleText.text = "사냥감을 발견했으나, 마땅한 도구가 없었다.";
            this.contentText.text = "도구 제작은 '인벤토리'에서 할 수 있다." + "\n" 
                                                              + "우선 제작에 필요한 재료를 모아보자.";
        }
        else {
            // TODO: (모바일) 진동을 주면 좋을텐데...
            this.titleText.text = "사냥에 성공했다.";
            
            foreach (var VARIABLE in resultItems) {
                this.content += "- " + VARIABLE.Key + " " + VARIABLE.Value.ToString("+#;-#;0") + "\n";
            }

            this.contentText.text = this.content;
        }
    }
    
    public void Injured(int duration) {
        this.content = "";

        this.titleText.text = "생각보다 큰 부상을 입었다.";
        this.content = "부상이 회복될 때까지 " + duration + "텀 동안 다른 지역으로 이동할 수 없다." + "\n"
                                                        + "부상을 입은 경우, 소모되는 상태 수치량이 2배 증가한다.";
        
        this.contentText.text = this.content;
    }

    public void InDanger() {
        
    }
}