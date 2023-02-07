using Microsoft.Maui.Controls;
using System.Globalization;
using WA_Utility.Service;
using WA_WeatherAPI.Model;
using WA_WeatherAPI.Service;

namespace WA_UnitTests;

public class WA_WeatherAPITests
{
    [Fact]
    public void ExampleTest()
    {
        string value = "*Castowanie zaklęcia*";
        WA_WeatherAPI.Service.ExampleService example = new();
        Assert.True(example.Value == value);
    }

    [Fact]
    public async void Current()
    {
        using HttpClient _client = new();
        Localization localization = new();
        Forecast forecast = new(localization);

        (double lat, double lon) = (await localization.Data());
        using HttpResponseMessage response = await _client.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}&longitude={lon.ToString(CultureInfo.InvariantCulture)}&timezone=auto&current_weather=true");
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async void Hourly()
    {
        using HttpClient _client = new();
        Localization localization = new();
        Forecast forecast = new(localization);
        int beforedays = 0;
        int afterdays = 14;

        (double lat, double lon) = (await localization.Data());
        using HttpResponseMessage response = await _client.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}&longitude={lon.ToString(CultureInfo.InvariantCulture)}&timezone=auto&start_date={DateTime.UtcNow.AddDays(beforedays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&end_date={DateTime.UtcNow.AddDays(afterdays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,precipitation,weathercode,surface_pressure,cloudcover,visibility");
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async void Daily()
    {
        using HttpClient _client = new();
        Localization localization = new();
        Forecast forecast = new(localization);
        int beforedays = -14;
        int afterdays = 14;

        (double lat, double lon) = (await localization.Data());
        using HttpResponseMessage response = await _client.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}&longitude={lon.ToString(CultureInfo.InvariantCulture)}&timezone=auto&start_date={DateTime.UtcNow.AddDays(beforedays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&end_date={DateTime.UtcNow.AddDays(afterdays).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_sum,precipitation_hours,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant,shortwave_radiation_sum");
        Assert.True(response.IsSuccessStatusCode);
    }
}