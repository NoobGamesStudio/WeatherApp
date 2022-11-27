using WA_WeatherAPI.Model;
using WA_WeatherAPI.Service;

namespace WA_UnitTests;

public class WA_WeatherAPITests
{
    [Fact]
    public void ExampleTest()
    {
        string value = "*Castowanie zaklęcia*";
        ExampleService example = new();
        Assert.True(example.Value == value);
    }
}