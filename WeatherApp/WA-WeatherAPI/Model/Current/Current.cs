namespace WA_WeatherAPI.Model.Current;

public record Current
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("current_weather")]
    public CurrentWeather? CurrentWeather { get; init; }
}

public record CurrentWeather
{
    [JsonPropertyName("temperature")]
    public double Temperature { get; init; }

    [JsonPropertyName("windspeed")]
    public double Windspeed { get; init; }

    [JsonPropertyName("winddirection")]
    public float Winddirection { get; init; }

    [JsonPropertyName("weathercode")]
    public long Weathercode { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }
}
