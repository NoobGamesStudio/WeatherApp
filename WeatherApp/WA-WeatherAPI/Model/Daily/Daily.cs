namespace WA_WeatherAPI.Model.Daily
{
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

    public record DailyData
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
    }

    public record DailyUnits
    {
        [JsonPropertyName("time")]
        public string? Time { get; init; }

        [JsonPropertyName("weathercode")]
        public string? Weathercode { get; init; }

        [JsonPropertyName("temperature_2m_max")]
        public string? Temperature2MMax { get; init; }

        [JsonPropertyName("temperature_2m_min")]
        public string? Temperature2MMin { get; init; }

        [JsonPropertyName("sunrise")]
        public string? Sunrise { get; init; }

        [JsonPropertyName("sunset")]
        public string? Sunset { get; init; }

        [JsonPropertyName("precipitation_sum")]
        public string? PrecipitationSum { get; init; }

        [JsonPropertyName("precipitation_hours")]
        public string? PrecipitationHours { get; init; }

        [JsonPropertyName("windspeed_10m_max")]
        public string? Windspeed10MMax { get; init; }

        [JsonPropertyName("windgusts_10m_max")]
        public string? Windgusts10MMax { get; init; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public string? Winddirection10MDominant { get; init; }

        [JsonPropertyName("shortwave_radiation_sum")]
        public string? ShortwaveRadiationSum { get; init; }
    }
}
