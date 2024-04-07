using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRandomEventSearch : MonoBehaviour {
    private List<IGameRandomEvent> randomEvents;
    private float weightSum;
    private float weightLimit;

    public delegate void SearchEventHandler();
    public static SearchEventHandler OnSearchRandomEvent;


    private void Init() {
        this.randomEvents = gameObject.GetComponents<IGameRandomEvent>().ToList();
        
        OnSearchRandomEvent += RandomEventSelect;
    }

    private void Awake() {
        Init();
    }

    private void RandomEventSelect() {
        this.weightSum = 0;
        this.weightLimit = Random.Range(0, 100);

        foreach (var VARIABLE in this.randomEvents) {
            this.weightSum += VARIABLE.Weight;
            
            if (this.weightSum > this.weightLimit) {
                VARIABLE.Event();
                
                break;
            }
        }
    }
}
