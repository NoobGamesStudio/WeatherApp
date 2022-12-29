using System.Text.Json;
using System.Text.Json.Serialization;

namespace WA_WeatherAPI.Model.Current
{
    public partial class Current
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

        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }

    public partial class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("windspeed")]
        public double Windspeed { get; set; }

        [JsonPropertyName("winddirection")]
        public long Winddirection { get; set; }

        [JsonPropertyName("weathercode")]
        public long Weathercode { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }
    }

    public partial class Current
    {
        public static Current FromJson(string json) => JsonSerializer.Deserialize<Current>(json, Converter.Settings);
    }
}
