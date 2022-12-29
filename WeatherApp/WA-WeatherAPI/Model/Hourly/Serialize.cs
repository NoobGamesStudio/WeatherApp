using System.Text.Json;

namespace WA_WeatherAPI.Model.Hourly
{
    public static class Serialize
    {
        public static string ToJson(this Hourly self) => JsonSerializer.Serialize(self, Converter.Settings);
    }
}
