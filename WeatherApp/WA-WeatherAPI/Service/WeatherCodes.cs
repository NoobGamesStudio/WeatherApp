namespace WA_WeatherAPI.Service;

public static class WeatherCodes
{
    public static Dictionary<int, string> weatherecode = new()
    {
        {0, "Clear sky"},
        {1, "Mainly clear"},
        {2, "Partly cloudly"},
        {3, "Overcast"},
        {45, "Fog"},
        {48, "Deposing rime fog"},
        {51, "Light drizzle"},
        {53, "Moderate drizzle"},
        {55, "Dense drizzle"},
        {56, "Light freezing drizzle"},
        {57, "Dense freezing drizzle"},
        {61, "Slight rain"},
        {63, "Moderate rain"},
        {65, "Heavy rain"},
        {66, "Light freezing rain"},
        {67, "Heavy freezing rain"},
        {71, "Slight snow fall"},
        {73, "Moderate snow fall"},
        {75, "Heavy snow fall"},
        {77, "Snow grains"},
        {80, "Slight rain showers"},
        {81, "Moderate rain showers"},
        {82, "Violent rain showers"},
        {85, "Slight snow showers"},
        {86, "Heavy snow showers"},
        {95, "Thunderstorm: slight or moderate"},
        {96, "Thunderstorm with slight hail"},
        {99, "Thunderstorm with hravy hail"}
    };
}
