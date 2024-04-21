using UnityEngine;

public class StatusEffectInjured : StatusEffect {
    private float statusMultiplier;

    public StatusEffectInjured() {
        this.name = "부상";
        this.type = GameControlType.StatusEffect.DURATION;
        this.durationTerm = Random.Range(1, 5) * 500;
        this.statusMultiplier = 2f;
    }
}