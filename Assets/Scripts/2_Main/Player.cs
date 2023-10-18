using System;
using System.Collections.Generic;
using UnityEngine;

public struct Player {
    public int Stamina { get; set; }
    public int BodyHeat { get; set; }
    public int Hydration { get; set; }
    public int Calories { get; set; }
    public string CurrentStatus { get; set; }
    public Dictionary<GameObject, int> Inventory;
}