using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class Player : GameControlSingleton<Player> { // Model
    private PlayerInformation information;
    private GameControlDictionary.Inventory inventory;          // <name, amount>
    public GameControlDictionary.Status Status { get; private set; }                // <Enum, float>
    private GameControlDictionary.StatusEffect statusEffect;    // <Enum, term>
    private Dictionary<GameControlType.StatusEffect, IPlayerStatusEffect> statusEffectMap;
    
    [SerializeField] private UnityEvent onStatusUpdate;
    [SerializeField] private UnityEvent onStatusEffectUpdate;
    
    
    private void Init() {
        this.information = GameInformationManager.Instance.playerInformation;
        this.statusEffectMap = new();
        
        this.inventory = this.information.inventory;
        this.Status = this.information.status;
        this.statusEffect = this.information.statusEffect;
        
        this.onStatusUpdate.Invoke();

        foreach (var VARIABLE in GetComponents<IPlayerStatusEffect>()) {
            this.statusEffectMap[VARIABLE.Type] = VARIABLE;
        }
        
        foreach (var VARIABLE in this.statusEffect) {
            this.statusEffectMap[VARIABLE.Key].Init(this.statusEffect[VARIABLE.Key]);
            this.onStatusEffectUpdate.AddListener(this.statusEffectMap[VARIABLE.Key].Invoke);
        }
    }

    private void Awake() {
    }
    
    private void Start() {  
        Init();
    }

    // type 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(GameControlType.Status type, float value) {
        // JSON 데이터 업데이트
        this.Status[type] += Mathf.Floor(value);
        this.Status[type] = Mathf.Clamp(this.Status[type], 0f, 100f);
        
        // 객체 데이터 업데이트
        this.onStatusUpdate.Invoke();
    }

    public void StatusUpdate(float stamina, float bodyHeat, float hydration, float calories) {
        this.Status[GameControlType.Status.STAMINA] += Mathf.Floor(stamina);
        this.Status[GameControlType.Status.BODY_HEAT] += Mathf.Floor(bodyHeat);
        this.Status[GameControlType.Status.HYDRATION] += Mathf.Floor(hydration);
        this.Status[GameControlType.Status.CALORIES] += Mathf.Floor(calories);

        this.Status[GameControlType.Status.STAMINA] =
            Mathf.Clamp(this.Status[GameControlType.Status.STAMINA], 0f, 100f);
        this.Status[GameControlType.Status.BODY_HEAT] =
            Mathf.Clamp(this.Status[GameControlType.Status.BODY_HEAT], 0f, 100f);
        this.Status[GameControlType.Status.HYDRATION] =
            Mathf.Clamp(this.Status[GameControlType.Status.HYDRATION], 0f, 100f);
        this.Status[GameControlType.Status.CALORIES] =
            Mathf.Clamp(this.Status[GameControlType.Status.CALORIES], 0f, 100f);
        
        this.onStatusUpdate.Invoke();
    }

    public void StatusEffectInvoke() {
        this.onStatusEffectUpdate.Invoke();
    }
    
    // type 상태 이상 효과 추가 
    public void StatusEffectAdd(IPlayerStatusEffect effect) {
        // if (!this.StatusEffect.TryAdd(effect.Type, effect.Term)) {  // 이미 있음
        //     this.StatusEffect[effect.Type] = effect.Term;
        // }
        // else {  // 신규 할당
        //     OnStatusEffectInvoke += effect.Invoke;
        // }
    }

    public void StatusEffectUpdate(IPlayerStatusEffect effect) {
        this.statusEffect[effect.Type] = effect.Term;
    }
    
    // type 상태 이상 효과 삭제
    public void StatusEffectRemove(IPlayerStatusEffect effect) {
        this.statusEffect.Remove(effect.Type);
    }
    
    // 인벤토리에 type 아이템이 존재하는가?
    public bool InventoryCheck(string type) {
        return this.inventory.ContainsKey(type);
    }
    
    // 인벤토리에 type 아이템들을 업데이트; ItemGet
    public void InventoryUpdate(Dictionary<string, int> items) {
        foreach (var VARIABLE in items) {
            if (this.inventory.ContainsKey(VARIABLE.Key)) {
                this.inventory[VARIABLE.Key] += VARIABLE.Value;
            }
            else {
                this.inventory[VARIABLE.Key] = VARIABLE.Value;
            }
        }
    }

    public void InventoryUpdate(string item, int value) {
        if (!this.inventory.TryAdd(item, value)) {
            this.inventory[item] += value;
        }
    }
}