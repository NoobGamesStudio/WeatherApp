namespace WA_Utility.Service;

public class Localization
{
    public string City { get; set; } = "Szczecin";
    string _lastCity = "Szczecin";
    Uri Uri => new Uri($"https://geocoding-api.open-meteo.com/v1/search?name={City}&count=1");
    public async Task<Result> Data()
    {
        var res = (await _client.GetFromJsonAsync<Root>(Uri))?.results?[0];

        // Fallback - get data of last valid city (should be geolocation)
        if (res == null)
        {
            City = _lastCity;
            res = (await _client.GetFromJsonAsync<Root>(Uri))?.results?[0];
        }
        else
        {
            _lastCity = City;
        }
        return res;
    }
    
    HttpClient _client = new HttpClient();

    ~Localization() => _client.Dispose();
}