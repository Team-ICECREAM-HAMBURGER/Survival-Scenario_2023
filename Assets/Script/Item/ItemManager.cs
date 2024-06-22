using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] public GameControlDictionary.ItemFood ItemFoods { get; private set; }
    [field: SerializeField] public GameControlDictionary.ItemMaterial ItemMaterials { get; private set; }
    [field: SerializeField] public GameControlDictionary.ItemTool ItemTools { get; private set; }

    [SerializeField] private Transform inventoryViewPortContent;

    public Dictionary<GameControlType.Item, IItem> Items { get; private set; }
    
    private float randomPercentSum;
    
    private UnityEvent<float, Transform> OnItemInit;
    
    
    private void Init() {
        this.Items = new();
        this.OnItemInit = new();
        this.randomPercentSum = 0;
        
        // TODO: 랜덤 아이템 획득 확률 계산 기능 수정; 무작위 획득이 아닌 것도 % 계산에 0으로 포함되고 있음; if() 사용 고려
        foreach (var VARIABLE in this.ItemFoods) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        foreach (var VARIABLE in this.ItemMaterials) {
            this.randomPercentSum += VARIABLE.Value.RandomPercent;
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value); 
        }
        
        foreach (var VARIABLE in this.ItemTools) {
            this.OnItemInit.AddListener(VARIABLE.Value.Init);
            this.Items.Add(VARIABLE.Key, VARIABLE.Value);
        }
        
        this.OnItemInit.Invoke(this.randomPercentSum, this.inventoryViewPortContent);
    }
    
    private void Awake() {
        Init();
    }
}