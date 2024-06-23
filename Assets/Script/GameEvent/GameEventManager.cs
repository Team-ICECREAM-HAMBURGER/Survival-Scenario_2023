using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : GameControlSingleton<GameEventManager> {
    private float percentSum;
    private float percentLimit;
    private float pivot;
    private float pivotSum;
    
    
    private void Init() {
        this.percentSum = 0f;
        this.percentLimit = 0f;
        this.pivot = 0f;
        this.pivotSum = 0f;
    }

    private void Awake() {
        Init();
    }
    
    public IGameRandomEvent RandomEventPercentSelect(List<IGameRandomEvent> randomEvents) {    // Random Event; Search
        this.percentSum = 0f;
        this.percentLimit = Random.Range(0f, 100f);
        
        foreach (var VARIABLE in randomEvents) {
            this.percentSum += VARIABLE.Percent;
            
            if (this.percentSum > this.percentLimit) {
                return VARIABLE;
            }
        }

        return null;
    }

    public bool RandomEventPercentSelect(float value) {
        this.percentSum = 0f;
        this.percentLimit = Random.Range(0f, 100f);

        return (value >= this.percentLimit);
    }

    public Dictionary<IItem, int> RandomItemWeightSelect(int value, Dictionary<GameControlType.Item, IItem> target) {
        var result = new Dictionary<IItem, int>();
        
        for (var i = 0; i < value; i++) {
            this.pivot = Random.Range(0f, 1f);
            this.pivotSum = 0f;
            
            foreach (var VARIABLE in target.Values) {
                this.pivotSum += VARIABLE.RandomWeight;

                if (this.pivotSum >= pivot) {
                    // 획득
                    if (!result.TryAdd(VARIABLE, Random.Range(1, VARIABLE.RandomMaxValue + 1))) {
                        result[VARIABLE] += Random.Range(1, VARIABLE.RandomMaxValue + 1);
                    }
                    
                    break;
                }
            }
        }
        
        return result;
    }
}