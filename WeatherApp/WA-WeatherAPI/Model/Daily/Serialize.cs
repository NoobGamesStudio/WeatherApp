using System.Text.Json;

namespace WA_WeatherAPI.Model.Daily
{
    public static class Serialize
    {
        public static string ToJson(this Daily self) => JsonSerializer.Serialize(self, Converter.Settings);
    }
}
