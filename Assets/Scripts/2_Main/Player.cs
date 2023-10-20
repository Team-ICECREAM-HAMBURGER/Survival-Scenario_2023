using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public class Status {
        public int Stamina { get; set; }
        public int BodyHeat { get; set; }
        public int Hydration { get; set; }
        public int Calories { get; set; }
        public Dictionary<string, bool> CurrentStatusEffect = new Dictionary<string, bool>();
    }

    public static Player Instance;
    public Status PlayerStatus;
    
    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;
        
        this.PlayerStatus = new Status();
    }

    private void Awake() {
        Init();
    }
    
    public bool CanBehaviour(Behaviour behaviour) {
        switch (behaviour) {
            case Behaviour.MOVE :
                if (this.PlayerStatus.Stamina > 25 && this.PlayerStatus.BodyHeat > 25 &&
                    this.PlayerStatus.Calories > 25 && this.PlayerStatus.Hydration > 25) {
                    if (!this.PlayerStatus.CurrentStatusEffect["Injured"]) {
                        return true;
                    }
                }
                
                return false;
        }
        
        return false;
    }
}