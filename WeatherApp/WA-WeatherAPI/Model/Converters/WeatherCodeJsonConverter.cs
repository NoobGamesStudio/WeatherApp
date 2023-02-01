namespace WA_WeatherAPI.Model.Converters;

internal class WeatherCodeJsonConverter : JsonConverter<List<string>>
{
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
            if(!SingleWeatherCodeJsonConverter.WeathereCodes.TryGetValue(code, out string value))
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

internal class SingleWeatherCodeJsonConverter : JsonConverter<string>
{
    public static Dictionary<int, string> WeathereCodes = new()
    {
        {0, "clear_sky"},
        {1, "mainly_clear"},
        {2, "partly_cloudly"},
        {3, "overcast"},
        {45, "fog"},
        {48, "rime_fog"},
        {51, "drizzle_light"},
        {53, "drizzle_moderate"},
        {55, "drizzle_dense"},
        {56, "freezing_drizzle_light"},
        {57, "freezing_drizzle_dense"},
        {61, "rain_slight"},
        {63, "rain_moderate"},
        {65, "rain_heavy"},
        {66, "freezing_rain_light"},
        {67, "freezing_rain_heavy"},
        {71, "snow_fall_slight"},
        {73, "snow_fall_moderate"},
        {75, "snow_fall_heavy"},
        {77, "snow_grains"},
        {80, "rain_showers_slight"},
        {81, "rain_showers_moderate"},
        {82, "rain_showers_violent"},
        {85, "snow_showers_slight"},
        {86, "snow_showers_heavy"},
        {95, "thunderstorm_slight"},
        {96, "thunderstorm_slight_hail"},
        {99, "thunderstorm_heavy_hail"}
    };

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Throw if current token in stream is not the array start
        if (reader.TokenType != JsonTokenType.Number)
            throw new JsonException("Given token is not a Number");

        // Try parsing given token as integer
        if (!reader.TryGetInt32(out int code))
            throw new JsonException("Given token is not an Int32");

        // Search for weather code
        if (!WeathereCodes.TryGetValue(code, out string value))
            throw new JsonException($"Given code: {code} does't match any weathercode");

        return value;
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        throw new JsonException("Serialization is not supported");
    }
}