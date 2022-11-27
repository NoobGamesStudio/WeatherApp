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
}