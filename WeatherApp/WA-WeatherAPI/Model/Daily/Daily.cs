using System.Text.Json;
using System.Text.Json.Serialization;

namespace WA_WeatherAPI.Model.Daily
{
    public partial class Daily
    {

        [JsonPropertyName("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public long UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public long Elevation { get; set; }

        [JsonPropertyName("daily_units")]
        public DailyUnits DailyUnits { get; set; }

        [JsonPropertyName("daily")]
        public DailyClass DailyWeather { get; set; }
    }

    public partial class DailyClass
    {
        [JsonPropertyName("time")]
        public DateTimeOffset[] Time { get; set; }

        [JsonPropertyName("weathercode")]
        public long[] Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public double[] Temperature2MMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public double[] Temperature2MMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string[] Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string[] Sunset { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public double[] PrecipitationSum { get; set; }

        [JsonPropertyName("precipitation_hours")]
        public long[] PrecipitationHours { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public double[] Windspeed10MMax { get; set; }

        [JsonPropertyName("windgusts_10m_max")]
        public double[] Windgusts10MMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public long[] Winddirection10MDominant { get; set; }

        [JsonPropertyName("shortwave_radiation_sum")]
        public double[] ShortwaveRadiationSum { get; set; }
    }

    public partial class DailyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("weathercode")]
        public string Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string Temperature2MMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string Temperature2MMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public string PrecipitationSum { get; set; }

        [JsonPropertyName("precipitation_hours")]
        public string PrecipitationHours { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public string Windspeed10MMax { get; set; }

        [JsonPropertyName("windgusts_10m_max")]
        public string Windgusts10MMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public string Winddirection10MDominant { get; set; }

        [JsonPropertyName("shortwave_radiation_sum")]
        public string ShortwaveRadiationSum { get; set; }
    }

    public partial class Daily
    {
        public static Daily FromJson(string json) => JsonSerializer.Deserialize<Daily>(json, Converter.Settings);
    }
}
