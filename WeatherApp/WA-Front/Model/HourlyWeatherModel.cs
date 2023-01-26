namespace WA_Front.Model;

public record HourlyWeatherModel
{
    public float Temperature { get; init; }
    public float Rain { get; init; }
    public string ImageSource { get; init; }
    public float RealTemperature { get; init; }
}
