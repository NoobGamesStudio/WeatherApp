namespace WA_WeatherAPI.Model.Daily;

public record Daily
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("daily_units")]
    public DailyUnits? Units { get; init; }

    [JsonPropertyName("daily")]
    public DailyData? Data { get; init; }
}

public record DailyData : ICastable<DailyDataModel>
{
    [JsonPropertyName("time")]
    public List<DateTimeOffset>? Time { get; init; }

    [JsonPropertyName("weathercode")]
    public List<long>? Weathercode { get; init; }

    [JsonPropertyName("temperature_2m_max")]
    public List<double>? Temperature2MMax { get; init; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double>? Temperature2MMin { get; init; }

    [JsonPropertyName("sunrise")]
    public List<string>? Sunrise { get; init; }

    [JsonPropertyName("sunset")]
    public List<string>? Sunset { get; init; }

    [JsonPropertyName("precipitation_sum")]
    public List<double>? PrecipitationSum { get; init; }

    [JsonPropertyName("precipitation_hours")]
    public List<float>? PrecipitationHours { get; init; }

    [JsonPropertyName("windspeed_10m_max")]
    public List<double>? Windspeed10MMax { get; init; }

    [JsonPropertyName("windgusts_10m_max")]
    public List<double>? Windgusts10MMax { get; init; }

    [JsonPropertyName("winddirection_10m_dominant")]
    public List<long>? Winddirection10MDominant { get; init; }

    [JsonPropertyName("shortwave_radiation_sum")]
    public List<double>? ShortwaveRadiationSum { get; init; }

    public List<DailyDataModel> Cast()
    {
        var res = new List<DailyDataModel>();

        for (int i = 0; i < Time.Count; i++)
        {
            res.Add(new DailyDataModel
            {
                Time = Time[i],
                Weathercode = Weathercode[i],
                Temperature2MMax = Temperature2MMax[i],
                Temperature2MMin = Temperature2MMin[i],
                Sunrise = Sunrise[i],
                Sunset = Sunset[i],
                PrecipitationSum = PrecipitationSum[i],
                PrecipitationHours = PrecipitationHours[i],
                Windspeed10MMax = Windspeed10MMax[i],
                Windgusts10MMax = Windgusts10MMax[i],
                Winddirection10MDominant = Winddirection10MDominant[i],
                ShortwaveRadiationSum = ShortwaveRadiationSum[i],
            });
        }
        return res;
    }
}

public record DailyDataModel
{
    public DateTimeOffset? Time { get; init; }
    public long? Weathercode { get; init; }
    public double? Temperature2MMax { get; init; }
    public double? Temperature2MMin { get; init; }
    public string? Sunrise { get; init; }
    public string? Sunset { get; init; }
    public double? PrecipitationSum { get; init; }
    public float? PrecipitationHours { get; init; }
    public double? Windspeed10MMax { get; init; }
    public double? Windgusts10MMax { get; init; }
    public long? Winddirection10MDominant { get; init; }
    public double? ShortwaveRadiationSum { get; init; }
}

public record DailyUnits
{
    [JsonPropertyName("time")]
    public List<string?> Time { get; init; }

    [JsonPropertyName("weathercode")]
    public List<string?> Weathercode { get; init; }

    [JsonPropertyName("temperature_2m_max")]
    public List<string?> Temperature2MMax { get; init; }

    [JsonPropertyName("temperature_2m_min")]
    public List<string?> Temperature2MMin { get; init; }

    [JsonPropertyName("sunrise")]
    public List<string?> Sunrise { get; init; }

    [JsonPropertyName("sunset")]
    public List<string?> Sunset { get; init; }

    [JsonPropertyName("precipitation_sum")]
    public List<string?> PrecipitationSum { get; init; }

    [JsonPropertyName("precipitation_hours")]
    public List<string?> PrecipitationHours { get; init; }

    [JsonPropertyName("windspeed_10m_max")]
    public List<string?> Windspeed10MMax { get; init; }

    [JsonPropertyName("windgusts_10m_max")]
    public List<string?> Windgusts10MMax { get; init; }

    [JsonPropertyName("winddirection_10m_dominant")]
    public List<string?> Winddirection10MDominant { get; init; }

    [JsonPropertyName("shortwave_radiation_sum")]
    public List<string?> ShortwaveRadiationSum { get; init; }

    public List<DailyUnitsModel> Cast()
    {
        var res = new List<DailyUnitsModel>();

        for (int i = 0; i < Time.Count; i++)
        {
            res.Add(new DailyUnitsModel
            {
                Time = Time[i],
                Weathercode = Weathercode[i],
                Temperature2MMax = Temperature2MMax[i],
                Temperature2MMin = Temperature2MMin[i],
                Sunrise = Sunrise[i],
                Sunset = Sunset[i],
                PrecipitationSum = PrecipitationSum[i],
                PrecipitationHours = PrecipitationHours[i],
                Windspeed10MMax = Windspeed10MMax[i],
                Windgusts10MMax = Windgusts10MMax[i],
                Winddirection10MDominant = Winddirection10MDominant[i],
                ShortwaveRadiationSum = ShortwaveRadiationSum[i],
            });
        }
        return res;
    }
}

public record DailyUnitsModel
{
    public string? Time { get; init; }
    public string? Weathercode { get; init; }
    public string? Temperature2MMax { get; init; }
    public string? Temperature2MMin { get; init; }
    public string? Sunrise { get; init; }
    public string? Sunset { get; init; }
    public string? PrecipitationSum { get; init; }
    public string? PrecipitationHours { get; init; }
    public string? Windspeed10MMax { get; init; }
    public string? Windgusts10MMax { get; init; }
    public string? Winddirection10MDominant { get; init; }
    public string? ShortwaveRadiationSum { get; init; }
}
