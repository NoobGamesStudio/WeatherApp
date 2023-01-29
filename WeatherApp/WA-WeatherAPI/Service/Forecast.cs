namespace WA_WeatherAPI.Service;

public class Forecast
{
    private readonly Localization _localization;
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://api.open-meteo.com/v1/")
    };

    public Forecast(Localization localization) => _localization = localization;
    ~Forecast() => _client.Dispose();

    public string City
    {
        get => _localization.City;
        set => _localization.City = value;
    }

    public async Task<Task<Current>> Current()
    {
        return _client.GetFromJsonAsync<Current>($"{await CommonUriPart()}&current_weather=true");
    }

    public async Task<Task<Hourly>> Hourly(int beforedays=0, int afterdays=1)
    {
        return _client.GetFromJsonAsync<Hourly>($"{await CommonUriPart()}&start_date={DateTime.UtcNow.AddDays(beforedays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&end_date={DateTime.UtcNow.AddDays(afterdays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,precipitation,weathercode,surface_pressure,cloudcover,visibility");
    }

    public async Task<Task<Daily>> Daily(int beforedays = -14, int afterdays = 14)
    {
        (double lon, double lat) = (await _localization.Data())!;

        return _client.GetFromJsonAsync<Daily>($"{await CommonUriPart()}&start_date={DateTime.UtcNow.AddDays(beforedays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&end_date={DateTime.UtcNow.AddDays(afterdays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_sum,precipitation_hours,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant,shortwave_radiation_sum");
    }

    async Task<string> CommonUriPart()
    {
        (double lon, double lat) = (await _localization.Data())!;

        StringBuilder builder = new();
        builder.Append($"forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}&longitude={lon.ToString(CultureInfo.InvariantCulture)}&timezone=auto");

        return builder.ToString();
    }
}
