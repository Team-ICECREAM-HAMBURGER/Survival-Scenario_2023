using System.Text;
using UnityEngine;

public class GameRandomEventFarming : MonoBehaviour, IGameRandomEvent {   // Presenter
    public float Weight { get; set; }
    private readonly StringBuilder resultText;


    private void Init() {
        IGameRandomEvent.OnPlayerBehaviourEvent += Event;
    }

    private void Awake() {
        Init();
    }

    public GameRandomEventFarming(float weight) {
        this.Weight = weight;
        this.resultText = new StringBuilder();
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
   
        // PlayerBehaviourSearchView.OnSearchResultUIFarming(Farming());
    }

    
    // private string Farming() {
    //     this.resultText.Clear();
    //     
    //     // UI Text; Result
    //     this.resultText.Append("- 결과\n");
    //     this.resultText.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");
    //     
    //     this.resultText.Append("\n");
    //     
    //     // UI Text; Status
    //     this.resultText.Append("- 스테이터스 잔여량\n");
    //     this.resultText.Append($"체력: {Player.Instance.StatusDictionary[GameTypeStatus.STAMINA]}%\n");
    //     this.resultText.Append($"체온: {Player.Instance.StatusDictionary[GameTypeStatus.BODY_HEAT]}%\n");
    //     this.resultText.Append($"수분: {Player.Instance.StatusDictionary[GameTypeStatus.HYDRATION]}%\n");
    //     this.resultText.Append($"열량: {Player.Instance.StatusDictionary[GameTypeStatus.CALORIES]}%\n");
    //     
    //     this.resultText.Append("\n");
    //     
    //     // UI Text; Items (1)
    //     this.resultText.Append("- 획득한 아이템\n");
    //     
    //     for (var i = 0; i < Random.Range(2, 4); i++) {
    //         float randomPivot = Random.Range(0, 100);
    //         float weight = 0;
    //         
    //         foreach (var variable in Player.Instance.Inventory.Where(variable => variable.Value.EventType == EventType.FARMING)) {
    //             if (weight + variable.Value.Weight >= randomPivot) {
    //                 // Item Get
    //                 var acquiredItemCount = variable.Value.ItemAcquire();
    //                 
    //                 // UI Text; Items (2)
    //                 this.resultText.Append($"{variable.Value.ItemName}: {acquiredItemCount}개\n");
    //                 
    //                 break;
    //             }
    //             
    //             weight += variable.Value.Weight;
    //         }
    //     }
    //     
    //     return this.resultText.ToString();
    // }
}