using System;

[Serializable]
public class WorldInformationData {
    public int timeTerm = 1;
    public int timeDay = 1;
    public string location = "조난 지역";
    public (GameControlType.Weather, string) weather = (GameControlType.Weather.CLEAR, "맑음");
    public bool hasShelter = false;
    public bool hasRainGutter = false;
    public bool hasWater = false;
    public bool hasFire = false;
    public bool isWinter = false;
    public int fireTerm = 0;
}