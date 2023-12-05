using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatusEffect : MonoBehaviour {
    public abstract int Duration { get; set; }
    public abstract string StatusEffectName { get; }
    public abstract statusEffectType StatusEffectType { get; }

    
    public virtual void StatusEffect() {
        return;
    }
}