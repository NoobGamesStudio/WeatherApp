using WA_Utility.Model;
using WA_Utility.Service;

namespace WA_UnitTests;

public class WA_UtilityTests
{
    [Fact]
    public void ExampleTest()
    {
        string value = "Dzieñ dobry";
        ExampleService example = new();
        Assert.True(example.Value == value);
    }

    [Fact]
    public async void LocalizationTest()
    {
        using HttpClient _client = new();
        Localization localization = new();

        using HttpResponseMessage response = await _client.GetAsync($"https://geocoding-api.open-meteo.com/v1/search?name={localization.City}&count=1");
        Assert.True(response.IsSuccessStatusCode);
    }
}