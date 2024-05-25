using System;
using UnityEngine;

[Serializable]
public class WorldInformation {
    public int timeTerm = 1;
    public int timeDay = 1;
    public string location = "조난 지역";
    public bool hasShelter = false;
    public bool hasRainGutter = false;
}