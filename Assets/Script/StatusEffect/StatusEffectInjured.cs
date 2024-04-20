using UnityEngine;

public class StatusEffectInjured : MonoBehaviour {
    class Property {
        public string StatusEffectName { get; } = "부상";
        public GameControlType.StatusEffect StatusEffectType { get; } = GameControlType.StatusEffect.INJURED;
    
        public int DurationTerm { get; set; }
        public float StatusDecreaseMultiplier { get; set; }
    }

    private Property property;
    

    private void Init() {
        this.property = new();
        StatusEffectManager.OnInjuredEffectEvent += Event;
    }

    private void Awake() {
        Init();
    }

    private void Event() {
        this.property.DurationTerm = Random.Range(1, 5) * 500;
        this.property.StatusDecreaseMultiplier = 2f;
        
        Player.Instance.StatusEffectUpdate(this.property);
    }
}