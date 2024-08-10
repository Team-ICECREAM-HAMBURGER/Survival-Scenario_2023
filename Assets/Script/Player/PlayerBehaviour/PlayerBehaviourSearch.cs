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
    [field: SerializeField] private GameControlDictionary.GameRandomEventWeight RandomEventWeight;

    [Space(25f)] 
    
    [Header("Random Collectable Item Weight")] 
    [field: SerializeField] private GameControlDictionary.GameRandomItemWeight RandomCollectableItemWeightFarming;
    [field: SerializeField] private GameControlDictionary.GameRandomItemWeight RandomCollectableItemWeightHunting;
    
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
    
    private float randomCollectableItemWeightFarmingTotal;
    private Dictionary<GameControlType.Item, float> randomCollectableItemWeightFarmingDictionary;
    
    private float randomEventWeightTotal;
    private Dictionary<GameControlType.RandomEvent, float> randomEventWeightDictionary;
    
    private Dictionary<GameControlType.RandomEvent, RandomEvent> randomEventDictionary;

    private string searchResultTitleText;
    private StringBuilder searchResultContentText;
    
    private delegate void RandomEvent();
    
    
    public override void Init() {
        this.searchSpendTime = 5;

        this.searchResultTitleText = String.Empty;
        this.searchResultContentText = new();
        
        this.randomEventDictionary = new() {
            { GameControlType.RandomEvent.FARM, RandomEventFarming },
            { GameControlType.RandomEvent.HUNT, RandomEventHunting },
            { GameControlType.RandomEvent.INJURED, RandomEventInjured }
        };
        
        this.randomCollectableItemWeightFarmingTotal = this.RandomCollectableItemWeightFarming.Sum(variable => variable.Value);
        this.randomCollectableItemWeightFarmingDictionary = DictionaryWeightSort(this.RandomCollectableItemWeightFarming, this.randomCollectableItemWeightFarmingTotal); 
        
        this.randomEventWeightTotal = this.RandomEventWeight.Sum(variable => variable.Value);
        this.randomEventWeightDictionary = DictionaryWeightSort(this.RandomEventWeight, this.randomEventWeightTotal);
    }

    private Dictionary<T, float> DictionaryWeightSort<T>(SerializableDictionary<T, float> value, float totalWeight) {
        return value.ToDictionary(
                v => v.Key,
                v => (v.Value / totalWeight)
            )
            .OrderBy(pair => pair.Value)
            .ToDictionary(
                pair => pair.Key,
                pair => pair.Value
            );
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

    private void RandomEventFarming() {
        Debug.Log("FarmEvent");
            
        var itemAmount = Random.Range(1, 4);
        Dictionary<GameControlType.Item, int> tempItemDictionaryFarming = new();
        
        // Panel Update
        this.searchResultTitleText = "탐색 결과";
        this.searchResultContentText.Clear();

        this.searchResultContentText.Append("- 결과\n");
        this.searchResultContentText.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");

        this.searchResultContentText.Append("\n");

        this.searchResultContentText.Append("- 획득한 아이템\n");
            
        // Player Inventory Update
        for (var i = 0; i < itemAmount; i++) {
            var weightSum = 0f;
            var randomPivot = Random.Range(0, 1f);
                
            foreach (var VARIABLE in this.randomCollectableItemWeightFarmingDictionary) {
                weightSum += VARIABLE.Value;
                    
                if (weightSum >= randomPivot) {
                    PlayerBehaviourManager.Instance.ItemAdd((VARIABLE.Key, 1));
                            
                    if (!tempItemDictionaryFarming.TryAdd(VARIABLE.Key, 1)) {
                        tempItemDictionaryFarming[VARIABLE.Key] += 1;
                    }
                        
                    break;
                }
            }
        }
        
        foreach (var VARIABLE in tempItemDictionaryFarming) {
            this.searchResultContentText.Append(PlayerBehaviourManager.Instance.GetItemName(VARIABLE.Key));
            this.searchResultContentText.Append(" ");
            this.searchResultContentText.Append(VARIABLE.Value);
            this.searchResultContentText.Append("개\n");
        }
    }

    private void RandomEventHunting() {
        Debug.Log("HuntEvent");
        
        var totalWeight = this.RandomCollectableItemWeightHunting.Sum(variable => variable.Value);
        var weightDictionary = DictionaryWeightSort(this.RandomCollectableItemWeightHunting, totalWeight);
        
        var itemAmount = Random.Range(1, 4);
        var weightSum = 0f;
        var randomPivot = Random.Range(0, 1f);

        if (CanBehaviour(GameControlType.Behaviour.SEARCH_HUNT)) {                
            // Panel Update
            this.searchResultTitleText = "탐색 결과";
            this.searchResultContentText.Clear();

            this.searchResultContentText.Append("- 결과\n");
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
            this.searchResultContentText.Append(PlayerBehaviourManager.Instance.GetItemName(GameControlType.Item.HUNTING_TOOL));
            this.searchResultContentText.Append(HUNTING_TOOL);
            this.searchResultContentText.Append("개\n");
        }
        else {
            this.searchResultTitleText = "탐색 결과";
            this.searchResultContentText.Clear();

            this.searchResultContentText.Append("- 결과\n");
            this.searchResultContentText.Append("사냥감을 발견했지만 마땅한 도구가 없어 놓치고 말았다.\n");
        }
    }

    private void RandomEventInjured() {
        Debug.Log("InjuredEvent");
            
        PlayerBehaviourManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.INJURED);
        
        // Panel Update
        this.searchResultTitleText = "탐색 결과";
        this.searchResultContentText.Clear();

        this.searchResultContentText.Append("- 결과\n");
        this.searchResultContentText.Append("탐색 도중 부상을 입고 말았다.\n");
        this.searchResultContentText.Append("무리한 활동보다는 부상을 회복하는 것이 우선이다.\n");
        this.searchResultContentText.Append("주변의 약초나 의약품이 도움이 될지도 모른다.\n");
        this.searchResultContentText.Append("휴식을 취하며 주변을 뒤져보자.\n");
    }
    
    private void RandomEventWeightSelect() {
        // Select Random Event & Call
        var weightSum = 0f;
        var randomPivot = Random.Range(0, 1f);
        
        foreach (var VARIABLE in this.randomEventWeightDictionary) {
            weightSum += VARIABLE.Value;
            
            if (weightSum >= randomPivot) {
                this.randomEventDictionary[VARIABLE.Key]();
                
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