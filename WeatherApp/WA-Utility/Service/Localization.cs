namespace WA_Utility.Service;

public class Localization
{
    public string City { get; set; } = "Szczecin";
    public Uri Uri => new Uri($"https://geocoding-api.open-meteo.com/v1/search?name={City}&count=1");
    public async Task<Result?> Data() => (await _client.GetFromJsonAsync<Root>(Uri))?.results?[0];
    
    HttpClient _client = new HttpClient();

    ~Localization() => _client.Dispose();
}