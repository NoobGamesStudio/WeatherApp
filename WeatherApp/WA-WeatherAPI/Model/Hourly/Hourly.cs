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

public record HourlyData : ICastable<HourlyDataModel>
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
    public string? Time { get; init; }
    public double? Temperature2M { get; init; }
    public long? Relativehumidity2M { get; init; }
    public double? ApparentTemperature { get; init; }
    public double? Precipitation { get; init; }
    public long? Weathercode { get; init; }
    public double? SurfacePressure { get; init; }
    public long? Cloudcover { get; init; }
    public float? Visibility { get; init; }
}

public record HourlyUnits : ICastable<HourlyUnitsModel>
{
    [JsonPropertyName("time")]
    public List<string?> Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public List<string?> Temperature2M { get; init; }

    [JsonPropertyName("relativehumidity_2m")]
    public List<string?> Relativehumidity2M { get; init; }

    [JsonPropertyName("apparent_temperature")]
    public List<string?> ApparentTemperature { get; init; }

    [JsonPropertyName("precipitation")]
    public List<string?> Precipitation { get; init; }

    [JsonPropertyName("weathercode")]
    public List<string?> Weathercode { get; init; }

    [JsonPropertyName("surface_pressure")]
    public List<string?> SurfacePressure { get; init; }

    [JsonPropertyName("cloudcover")]
    public List<string?> Cloudcover { get; init; }

    [JsonPropertyName("visibility")]
    public List<string?> Visibility { get; init; }

    public List<HourlyUnitsModel> Cast()
    {
        var res = new List<HourlyUnitsModel>();

        for (int i = 0; i < Time.Count; i++)
        {
            res.Add(new HourlyUnitsModel
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

public record HourlyUnitsModel
{
    public string? Time { get; init; }
    public string? Temperature2M { get; init; }
    public string? Relativehumidity2M { get; init; }
    public string? ApparentTemperature { get; init; }
    public string? Precipitation { get; init; }
    public string? Weathercode { get; init; }
    public string? SurfacePressure { get; init; }
    public string? Cloudcover { get; init; }
    public string? Visibility { get; init; }
}