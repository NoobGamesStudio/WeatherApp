namespace WA_WeatherAPI.Model.Hourly;

public record Hourly
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("hourly_units")]
    public HourlyUnits? Units { get; init; }

    [JsonPropertyName("hourly")]
    public HourlyData? Data { get; init; }
}

public record HourlyData
{
    [JsonPropertyName("time")]
    public List<string>? Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public List<double>? Temperature2M { get; init; }

    [JsonPropertyName("relativehumidity_2m")]
    public List<long>? Relativehumidity2M { get; init; }

    [JsonPropertyName("apparent_temperature")]
    public List<double>? ApparentTemperature { get; init; }

    [JsonPropertyName("precipitation")]
    public List<double>? Precipitation { get; init; }

    [JsonPropertyName("weathercode")]
    public List<long>? Weathercode { get; init; }

    [JsonPropertyName("surface_pressure")]
    public List<double>? SurfacePressure { get; init; }

    [JsonPropertyName("cloudcover")]
    public List<long>? Cloudcover { get; init; }

    [JsonPropertyName("visibility")]
    public List<float>? Visibility { get; init; }
}

public record HourlyUnits
{
    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public string? Temperature2M { get; init; }

    [JsonPropertyName("relativehumidity_2m")]
    public string? Relativehumidity2M { get; init; }

    [JsonPropertyName("apparent_temperature")]
    public string? ApparentTemperature { get; init; }

    [JsonPropertyName("precipitation")]
    public string? Precipitation { get; init; }

    [JsonPropertyName("weathercode")]
    public string? Weathercode { get; init; }

    [JsonPropertyName("surface_pressure")]
    public string? SurfacePressure { get; init; }

    [JsonPropertyName("cloudcover")]
    public string? Cloudcover { get; init; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; init; }
}
