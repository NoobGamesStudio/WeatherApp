using System.Text.Json;

namespace WA_WeatherAPI.Model.Daily
{
    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new JsonSerializerOptions
        {
            WriteIndented= true,
        };
    }
}
