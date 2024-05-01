using System.Collections.Generic;
using UnityEngine;

public class Player : GameControlSingleton<Player> { // Model
    private PlayerInformation information;

    private GameControlDictionary.Inventory inventory;          // <name, amount>
    public GameControlDictionary.Status Status { get; private set; }                // <Enum, float>
    public GameControlDictionary.StatusEffect StatusEffect { get; private set; }    // <name, term>
    
    /*
     * - Dictionary를 이용해 플레이어가 지니고 있는 객체들을 따로 관리한다면?
     * 객체에 직접 접근해서 사용할 수 있어서 지금보다 더 자유로워진다.
     * 자료형이 2배로 필요하기 때문에 부담이 되기는 함.
     * 값이 업데이트되면 Dictionary와 JSON을 함께 업데이트해야 함.
     *      --> Dictionary만 업데이트 하다가 텀이 차면 그때만 JSON 갱신?
     * Dictionary<name, IStatusEffect> PlayerStatusEffect { get; set; }
     * 객체를 인스턴스화하는 Init() 작업이 필요.
     *      --> Manager가 초기화를 한다.
     *      --> foreach()를 이용해서 JSON 파일을 조회하는 작업도 필요.
     *      --> 다만 foreach()를 통해 조회하는 작업은 manager에서 이미 진행 중.
     * 
     * - Status는?
     * Enum과 float으로 관리 중.
     * 클래스를 굳이 따로 만들어서 관리를 해야 하는가?
     *      --> 그래프 조작 등 Viewer에 대한 부분도 작업이 필요하다.
     * 
     * - Manager에 이미 레퍼런스 딕셔너리가 있는데, Player에게 또 딕셔너리가 따로 필요한가?
     * 플레이어가 소지하고 있는 아이템, 상태 이상, 상태 수치 등만 따로 골라서 관리 가능.
     * Manager의 레퍼런스 딕셔너리를 사용하여 딕셔너리 초기화.
     * 현재는 아이템이 추가되거나, 상태 이상 변경 등의 작업이 이루어지면 Manager를 참조하므로, 종속성이 강하다.
     * Init()에서 Player가 가지고 있는 상태를 설정할 때 레퍼런스로만 사용하고 Player는 독립할 수 있음.
     * Status, Inventory, StatusEffect는 JSON 저장용이므로, 데이터 왜곡이 없도록 캡슐화가 중요.
     */
    
    
    public delegate void StatusEffectInvokeHandler();
    public static StatusEffectInvokeHandler OnStatusEffectInvoke;
    
    
    private void Init() {
        this.information = GameInformation.Instance.playerInformation;
        
        this.inventory = this.information.inventory;
        this.Status = this.information.status;
        this.StatusEffect = this.information.statusEffect;
    }

    private void Start() {
        Init();
    }
    
    // type 상태의 수치가 value 이상인가?
    public bool StatusCheck(GameControlType.Status type, float value) { 
        return true;
    }

    // 모든 상태의 수치가 value 이상인가?
    public bool StatusCheck(float value) {
        return true;
    }
    
    // 각 상태의 수치가 모두 기준치를 넘는가?
    public bool StatusCheck(float stamina, float bodyHeat, float hydration, float calories) {
        return true;
    }

    // 각 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(float[] values) {
    }

    // type 상태의 수치를 value만큼 업데이트
    public void StatusUpdate(GameControlType.Status type, float value) {
        this.Status[type] += value;
        
        GameInformation.OnPlayerGameDataSave();
        GameInformation.OnWorldGameDataSave();
    }
    
    // type 상태 이상 효과가 적용되어 있는가?
    public bool StatusEffectCheck(string key) { 
        return this.StatusEffect.ContainsKey(key);
    }

    // 구독 중인 상태 이상에 효과 알림 전송
    public void StatusEffectInvoke() {
        OnStatusEffectInvoke?.Invoke();
    }
    
    // type 상태 이상 효과 업데이트 
    public void StatusEffectUpdate(IStatusEffect effect) {
        if (!this.StatusEffect.TryAdd(effect.Name, effect.Term)) {
            this.StatusEffect[effect.Name] = effect.Term;
        }
        else {
            OnStatusEffectInvoke += effect.Active;
        }
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