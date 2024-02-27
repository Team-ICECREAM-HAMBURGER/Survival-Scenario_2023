using System;
using System.Collections.Generic;

[Serializable]
public class PlayerInformation {
    public string name = String.Empty;
    public Dictionary<string, int> inventory = new();
    public Dictionary<GameTypeStatus, IPlayerStatus> status = new();
    public Dictionary<GameTypeStatusEffect, IPlayerStatusEffect> statusEffect = new();
}