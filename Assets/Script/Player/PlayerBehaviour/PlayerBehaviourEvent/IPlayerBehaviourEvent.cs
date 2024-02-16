using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    NONE,
    FARMING,
    HUNTING,
    INJURED,
    IN_DANGER
}

public interface IPlayerBehaviourEvent {
    float Weight { get; set; }
    void Event();
}