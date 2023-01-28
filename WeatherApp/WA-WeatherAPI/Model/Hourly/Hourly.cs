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
    public HourlyUnitsModel? Units { get; init; }

    [JsonPropertyName("hourly")]
    public HourlyData? Data { get; init; }
}

public record HourlyData : ICastable<HourlyDataModel>
{
    [JsonPropertyName("time")]
    public List<DateTime>? Time { get; init; }

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

    public List<HourlyDataModel> Cast()
    {
        var res = new List<HourlyDataModel>();

        for (int i = 0; i < Time.Count; i++)
        {
            res.Add(new HourlyDataModel
            {
                Time = Time[i],
                Temperature2M = Temperature2M[i],
                Relativehumidity2M = Relativehumidity2M[i],
                ApparentTemperature = ApparentTemperature[i],
                Precipitation = Precipitation[i],
                Weathercode = Weathercode[i],
                SurfacePressure = SurfacePressure[i],
                Cloudcover = Cloudcover[i],
                Visibility = Visibility[i]
            });
        }
        return res;
    }
}

public record HourlyDataModel
{
    public DateTime? Time { get; init; }
    public double? Temperature2M { get; init; }
    public long? Relativehumidity2M { get; init; }
    public double? ApparentTemperature { get; init; }
    public double? Precipitation { get; init; }
    public long? Weathercode { get; init; }
    public double? SurfacePressure { get; init; }
    public long? Cloudcover { get; init; }
    public float? Visibility { get; init; }
}

public record HourlyUnitsModel
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