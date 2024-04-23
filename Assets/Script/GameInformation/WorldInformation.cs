using System;
using UnityEngine;

[Serializable]
public class WorldInformation {
    public int timeTerm;
    public int timeDay;
    public IWeather weather;
    public ILocation location;
}