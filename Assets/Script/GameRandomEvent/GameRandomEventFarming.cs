using System;
using System.Text;
using UnityEngine;

public class GameRandomEventFarming : MonoBehaviour, IGameRandomEvent {
    public float Weight { get; private set; }
    
    private string title;
    private StringBuilder content;

    
    private void Init() {
        this.title = "탐색 결과";
        this.content = new StringBuilder();
    }

    private void Awake() {
        Init();
    }
    
    public (string title, string content) Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // TODO: Item Get
        
        // Result Text
        return Result();
    }

    public (string title, string content) Result() {
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");

        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");
        
        return (this.title, this.content.ToString());
    }
}