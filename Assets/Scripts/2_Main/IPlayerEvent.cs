using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    FARMING,
    HUNTING,
    INJURED,
    IN_DANGER
}

public interface IPlayerEvent {
    float Weight { get; set; }
    void Event();
}