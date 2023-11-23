using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eventType {
    FARMING,
    HUNTING,
    INJURED,
    IN_DANGER
}

public interface IPlayerSearchEvent {
    float Weight { get; set; }
    void Event();
}