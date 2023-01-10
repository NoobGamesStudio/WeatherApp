using System.Text.Json;
using System.Text.Json.Serialization;

namespace WA_WeatherAPI.Model.Hourly
{
    public partial class Hourly
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

        [JsonPropertyName("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        [JsonPropertyName("hourly")]
        public HourlyClass HourlyWeather { get; set; }
    }

    public partial class HourlyClass
    {
        [JsonPropertyName("time")]
        public string[] Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double[] Temperature2M { get; set; }

        [JsonPropertyName("relativehumidity_2m")]
        public long[] Relativehumidity2M { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public double[] ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation")]
        public double[] Precipitation { get; set; }

        [JsonPropertyName("weathercode")]
        public long[] Weathercode { get; set; }

        [JsonPropertyName("surface_pressure")]
        public double[] SurfacePressure { get; set; }

        [JsonPropertyName("cloudcover")]
        public long[] Cloudcover { get; set; }

        [JsonPropertyName("visibility")]
        public long[] Visibility { get; set; }
    }

    public partial class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature2M { get; set; }

        [JsonPropertyName("relativehumidity_2m")]
        public string Relativehumidity2M { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public string ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation")]
        public string Precipitation { get; set; }

        [JsonPropertyName("weathercode")]
        public string Weathercode { get; set; }

        [JsonPropertyName("surface_pressure")]
        public string SurfacePressure { get; set; }

        [JsonPropertyName("cloudcover")]
        public string Cloudcover { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }
    }

    public partial class Hourly
    {
        public static Hourly FromJson(string json) => JsonSerializer.Deserialize<Hourly>(json, Converter.Settings);
    }
}
