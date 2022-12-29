using System.Text.Json;

namespace WA_WeatherAPI.Model.Current
{
    public static class Serialize
    {
        public static string ToJson(this Current self) => JsonSerializer.Serialize(self, Converter.Settings);
    }
}
