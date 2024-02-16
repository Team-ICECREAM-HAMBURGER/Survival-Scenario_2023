using UnityEngine;

public class WeatherSnow : IWeather {
    public float FireWeight { get; } = 0.2f;

    public bool WillCatchFire() { 
        return Random.value <= this.FireWeight;
    }
}
