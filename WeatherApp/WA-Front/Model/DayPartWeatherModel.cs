namespace WA_Front.Model;

public record DayPartWeatherModel
{
    public string Part { get; init; }
    public float Temperature { get; init; }
    public float Rain { get; init; } 
    public string ImageSource { get; init; }
    public float RealTemperature { get; init; }
}
