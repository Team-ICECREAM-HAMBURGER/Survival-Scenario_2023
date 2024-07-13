using UnityEngine;

public class GameRandomEventManager : GameControlSingleton<GameRandomEventManager> {
    [field: SerializeField] public GameControlDictionary.GameRandomEvent GameRandomEvents { get; private set; }
    
    private float percentSum;
    private float percentLimit;
    private float pivot;
    private float pivotSum;
    
    
    private void Init() {
        this.percentSum = 0f;
        this.percentLimit = 0f;
        this.pivot = 0f;
        this.pivotSum = 0f;

        foreach (var VARIABLE in this.GameRandomEvents.Values) {
            VARIABLE.Init();
        }
    }

    private void Awake() {
        Init();
    }
    
    public GameRandomEvent RandomEventPercentSelect() {    // Random Event; Search
        this.percentSum = 0f;
        this.percentLimit = Random.Range(0f, 100f);
        
        foreach (var VARIABLE in this.GameRandomEvents.Values) {
            this.percentSum += VARIABLE.Percent;
            
            if (this.percentSum > this.percentLimit) {
                return VARIABLE;
            }
        }

        return null;
    }
    
    public bool RandomEventPercentSelect(float value) {
        this.percentLimit = Random.Range(0f, 100f);
    
        return (value >= this.percentLimit);
    }
}