using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerBehaviourSearch : PlayerBehaviour {   // Presenter
    [Space(25f)] 
    
    [Header("Search Random Event Weight")] 
    [field: SerializeField] private GameControlDictionary.GameRandomEventWeight searchRandomEventWeight;

    [Space(25f)] 
    
    [Header("Random Collectable Item")] 
    [field: SerializeField] private GameControlDictionary.GameRandomItemWeight RandomCollectableItemWeightfarming;
    [field: SerializeField] private GameControlDictionary.GameRandomItemWeight RandomCollectableItemWeighthunting;

    [Space(25f)] 
    
    [Header("Behaviour Require Item")] 
    [field: SerializeField] private UnityEvent OnItemUseHunting;
    
    [Space(25f)] 
    
    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject searchResultPanel;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;

    [Space(25f)]
    
    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject searchLoadingPanel;
    [SerializeField] private TMP_Text searchLoadingTitle;

    private static int HUNTING_TOOL = 1;
    
    private int searchSpendTime;
    
    private string searchResultTitleText;
    private StringBuilder searchResultContentText;
    
    private delegate void RandomEvent();
    
    
    public override void Init() {
        OnPlayerStatusUpdate = new();
        
        this.searchSpendTime = 5;
        
        this.searchResultTitleText = String.Empty;
        this.searchResultContentText = new();
    }

    private bool CanBehaviour(GameControlType.Behaviour type) {
        return PlayerBehaviourManager.Instance.CanBehaviour(type);
    }

    public override void Behaviour() {
        // Player Status Update
        OnPlayerStatusUpdate.Invoke();
        
        // Player Status Effects Invoke
        PlayerBehaviourManager.Instance.StatusEffectInvoke();
        
        // Random Event; Search
        RandomEventWeightSelect();
        
        // Word Info. Update
        PlayerBehaviourManager.Instance.WorldTimeUpdate(this.searchSpendTime);
        
        // Game Data Update
        PlayerBehaviourManager.Instance.GameDataSaveInvoke();
        
        // Panel Update
        PanelUpdate();
    }

    private void RandomEventWeightSelect() {
        var totalWeight = this.searchRandomEventWeight.Sum(variable => variable.Value);
        var weightDictionary = this.searchRandomEventWeight
            .ToDictionary(
                variable => variable.Key,
                variable => (variable.Value / totalWeight)
            )
            .OrderBy(pair => pair.Value)
            .ToDictionary(
                pair => pair.Key, 
                pair => pair.Value
            );
        var randomPivot = Random.Range(0, 1f);
        var weightSum = 0f;
        
        Dictionary<GameControlType.RandomEvent, RandomEvent> eventDictionary = new();
        
        RandomEvent FarmEvent = delegate() {
            Debug.Log("FarmEvent");
            
            var totalWeight = this.RandomCollectableItemWeightfarming.Sum(variable => variable.Value);
            var weightDictionary = this.RandomCollectableItemWeightfarming
                .ToDictionary(
                    variable => variable.Key,
                    variable => (variable.Value / totalWeight)
                )
                .OrderBy(pair => pair.Value)
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value
                );
            var itemAmount = Random.Range(1, 4);
            var weightSum = 0f;
            var randomPivot = Random.Range(0, 1f);
            
            // Panel Update
            this.searchResultTitleText = "탐색 결과";
            this.searchResultContentText.Clear();

            this.searchResultContentText.Append("- 결과\n");
            this.searchResultContentText.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");

            this.searchResultContentText.Append("\n");

            this.searchResultContentText.Append("- 획득한 아이템\n");
            
            // Player Inventory Update
            for (var i = 0; i < itemAmount; i++) {
                foreach (var VARIABLE in weightDictionary) {
                    weightSum += VARIABLE.Value;

                    if (weightSum >= randomPivot) {
                        var gotItem = PlayerBehaviourManager.Instance.ItemAdd((VARIABLE.Key, itemAmount));
                        
                        this.searchResultContentText.Append(gotItem);
                        this.searchResultContentText.Append(" ");
                        this.searchResultContentText.Append(itemAmount);
                        this.searchResultContentText.Append("개\n");
                        
                        weightSum = 0f;

                        break;
                    }
                }
            }
        };

        RandomEvent HuntEvent = delegate() {
            Debug.Log("HuntEvent");
            
            var totalWeight = this.RandomCollectableItemWeighthunting.Sum(variable => variable.Value);
            var weightDictionary = this.RandomCollectableItemWeighthunting
                .ToDictionary(
                    variable => variable.Key,
                    variable => (variable.Value / totalWeight)
                )
                .OrderBy(pair => pair.Value)
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value
                );
            var itemAmount = Random.Range(1, 4);
            var weightSum = 0f;
            var randomPivot = Random.Range(0, 1f);


            if (CanBehaviour(GameControlType.Behaviour.SEARCH_HUNT)) {
                // Panel Update
                this.searchResultTitleText = "탐색 결과";
                this.searchResultContentText.Clear();

                this.searchResultContentText.Append("- 결과");
                this.searchResultContentText.Append("끈질긴 추격 끝에 사냥에 성공했다.\n");

                this.searchResultContentText.Append("\n");

                this.searchResultContentText.Append("- 획득한 아이템\n");
            
                // Player Inventory Update
                for (var i = 0; i < itemAmount; i++) {
                    foreach (var VARIABLE in weightDictionary) {
                        weightSum += VARIABLE.Value;
                    
                        if (weightSum >= randomPivot) {
                            var getItem = PlayerBehaviourManager.Instance.ItemAdd((VARIABLE.Key, itemAmount));
                        
                            this.searchResultContentText.Append(getItem);
                            this.searchResultContentText.Append(" ");
                            this.searchResultContentText.Append(itemAmount);
                            this.searchResultContentText.Append("개\n");
                        
                            weightSum = 0f;

                            break;
                        }
                    }
                }

                this.OnItemUseHunting.Invoke();

                this.searchResultContentText.Append("- 소모한 아이템\n");
                this.searchResultContentText.Append(PlayerBehaviourManager.Instance.ItemGet(GameControlType.Item.HUNTING_TOOL));
                this.searchResultContentText.Append(HUNTING_TOOL);
                this.searchResultContentText.Append("개\n");
            }
            else {
                this.searchResultTitleText = "탐색 결과";
                this.searchResultContentText.Clear();

                this.searchResultContentText.Append("- 결과");
                this.searchResultContentText.Append("사냥감을 발견했지만 마땅한 도구가 없어 놓치고 말았다.\n");
            }
        };

        RandomEvent InjuredEvent = delegate() {
            Debug.Log("InjuredEvent");
            
            PlayerBehaviourManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.INJURED);
            
            // Panel Update
            this.searchResultTitleText = "탐색 결과";
            this.searchResultContentText.Clear();

            this.searchResultContentText.Append("- 결과");
            this.searchResultContentText.Append("탐색 도중 부상을 입고 말았다.\n");
            this.searchResultContentText.Append("무리한 활동보다는 부상을 회복하는 것이 우선이다.\n");
            this.searchResultContentText.Append("주변의 약초나 의약품이 도움이 될지도 모른다.\n");
            this.searchResultContentText.Append("휴식을 취하며 주변을 뒤져보자.\n");
        };
        
        
        eventDictionary.Add(GameControlType.RandomEvent.FARM, FarmEvent);
        eventDictionary.Add(GameControlType.RandomEvent.HUNT, HuntEvent);
        eventDictionary.Add(GameControlType.RandomEvent.INJURED, InjuredEvent);
        
        foreach (var VARIABLE in weightDictionary) {
            weightSum += VARIABLE.Value;
            
            if (weightSum >= randomPivot) {
                eventDictionary[VARIABLE.Key]();
                
                weightSum = 0f;
                
                break;
            }
        }
    }
    
    private void PanelUpdate() {
        this.searchLoadingTitle.text = "주변을 탐색하는 중...";
        this.searchResultTitle.text = this.searchResultTitleText;
        this.searchResultContent.text = this.searchResultContentText.ToString();
        
        this.searchLoadingPanel.SetActive(true);
        this.searchResultPanel.SetActive(true);
    }
}