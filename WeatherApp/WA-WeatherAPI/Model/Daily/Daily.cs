namespace WA_WeatherAPI.Model.Daily;

public record Daily : ICastable<DailyModel>
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; init; }

    [JsonPropertyName("daily_units")]
    public DailyUnitsModel Units { get; init; }

    [JsonPropertyName("daily")]
    public DailyData Data { get; init; }

    public List<DailyModel> Cast()
    {
        return Data?.Cast()
            .Select(d => new DailyModel
            {
                Data=d,
                Units=Units
            }).ToList();
    }
}

public record DailyData : ICastable<DailyDataModel>
{
    [JsonPropertyName("time")]
    public List<DateTime?> Time { get; init; }

    [JsonPropertyName("weathercode")]
    [JsonConverter(typeof(WeatherCodeJsonConverter))]
    public List<string> WeatherImage { get; init; }

    [JsonPropertyName("temperature_2m_max")]
    public List<double?> Temperature2MMax { get; init; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double?> Temperature2MMin { get; init; }

    [JsonPropertyName("sunrise")]
    public List<DateTime?> Sunrise { get; init; }

    [JsonPropertyName("sunset")]
    public List<DateTime?> Sunset { get; init; }

    [JsonPropertyName("precipitation_sum")]
    public List<double?> PrecipitationSum { get; init; }

    [JsonPropertyName("precipitation_hours")]
    public List<float?> PrecipitationHours { get; init; }

    [JsonPropertyName("windspeed_10m_max")]
    public List<double?> Windspeed10MMax { get; init; }

    [JsonPropertyName("windgusts_10m_max")]
    public List<double?> Windgusts10MMax { get; init; }

    [JsonPropertyName("winddirection_10m_dominant")]
    public List<long?> Winddirection10MDominant { get; init; }

    [JsonPropertyName("shortwave_radiation_sum")]
    public List<double?> ShortwaveRadiationSum { get; init; }

    public List<DailyDataModel> Cast()
    {
        var res = new List<DailyDataModel>();

        for (int i = 0; i < Time.Count; i++)
        {
            res.Add(new DailyDataModel
            {
                Time = Time[i],
                WeatherImage = WeatherImage[i],
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

public record DailyModel
{ 
    public DailyDataModel Data { get; init; }
    public DailyUnitsModel Units { get; init; }
}

public record DailyDataModel
{
    public DateTime? Time { get; init; }
    public string WeatherImage { get; init; }
    public double? Temperature2MMax { get; init; }
    public double? Temperature2MMin { get; init; }
    public DateTime? Sunrise { get; init; }
    public DateTime? Sunset { get; init; }
    public double? PrecipitationSum { get; init; }
    public float? PrecipitationHours { get; init; }
    public double? Windspeed10MMax { get; init; }
    public double? Windgusts10MMax { get; init; }
    public long? Winddirection10MDominant { get; init; }
    public double? ShortwaveRadiationSum { get; init; }
}

public record DailyUnitsModel
{
    [JsonPropertyName("time")]
    public string Time { get; init; }

    [JsonPropertyName("weathercode")]
    public string WeatherImage { get; init; }

    [JsonPropertyName("temperature_2m_max")]
    public string Temperature2MMax { get; init; }

    [JsonPropertyName("temperature_2m_min")]
    public string Temperature2MMin { get; init; }

    [JsonPropertyName("sunrise")]
    public string Sunrise { get; init; }

    [JsonPropertyName("sunset")]
    public string Sunset { get; init; }

    [JsonPropertyName("precipitation_sum")]
    public string PrecipitationSum { get; init; }

    [JsonPropertyName("precipitation_hours")]
    public string PrecipitationHours { get; init; }

    [JsonPropertyName("windspeed_10m_max")]
    public string Windspeed10MMax { get; init; }

    [JsonPropertyName("windgusts_10m_max")]
    public string Windgusts10MMax { get; init; }

    [JsonPropertyName("winddirection_10m_dominant")]
    public string Winddirection10MDominant { get; init; }

    [JsonPropertyName("shortwave_radiation_sum")]
    public string ShortwaveRadiationSum { get; init; }
}