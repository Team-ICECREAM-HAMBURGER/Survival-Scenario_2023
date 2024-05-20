using UnityEngine;

public class WeatherSunny : IWeather {
    public float FireWeight { get; } = 0.4f;

    public bool WillCatchFire() {
        return Random.value < this.FireWeight;
    }
}