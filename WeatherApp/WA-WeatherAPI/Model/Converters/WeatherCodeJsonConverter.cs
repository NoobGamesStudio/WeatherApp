namespace WA_WeatherAPI.Model.Converters;

internal class WeatherCodeJsonConverter : JsonConverter<List<string>>
{
    public static Dictionary<int, string> WeathereCodes = new()
    {
        {0, "Clear_sky"},
        {1, "Mainly_clear"},
        {2, "Partly_cloudly"},
        {3, "Overcast"},
        {45, "Fog"},
        {48, "Deposing_rime_fog"},
        {51, "Light_drizzle"},
        {53, "Moderate_drizzle"},
        {55, "Dense_drizzle"},
        {56, "Light_freezing_drizzle"},
        {57, "Dense_freezing_drizzle"},
        {61, "Slight_rain"},
        {63, "Moderate_rain"},
        {65, "Heavy_rain"},
        {66, "Light_freezing rain"},
        {67, "Heavy_freezing rain"},
        {71, "Slight_snow_fall"},
        {73, "Moderate_snow_fall"},
        {75, "Heavy_snow_fall"},
        {77, "Snow_grains"},
        {80, "Slight_rain_showers"},
        {81, "Moderate_rain_showers"},
        {82, "Violent_rain_showers"},
        {85, "Slight_snow_showers"},
        {86, "Heavy_snow_showers"},
        {95, "Thunderstorm_slight_or_moderate"},
        {96, "Thunderstorm_with_slight_hail"},
        {99, "Thunderstorm_with_hravy_hail"}
    };

    public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Throw if current token in stream is not the array start
        if(reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException("Given token is not an Array");

        List<string> list = new List<string>();

        // Read tokens from stream
        while(reader.Read()) 
        { 
            // If current token is end of array return list
            if(reader.TokenType == JsonTokenType.EndArray) 
                return list;

            // Try parsing given token as integer
            if(!reader.TryGetInt32(out int code))
                throw new JsonException("Given token is not an Int32");

            // Search for weather code
            if(!WeathereCodes.TryGetValue(code, out string value))
                throw new JsonException($"Given code: {code} does't match any weathercode");

            list.Add(value);
        }

        // Possible end of stream or ill formed json
        throw new JsonException("Invalid");
    }

    public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
    {
        throw new JsonException("Serialization is not supported");
    }
}
