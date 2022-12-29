using System.Text.Json;

namespace WA_WeatherAPI.Model.Current
{
    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
    }
}
