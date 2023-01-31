namespace WA_Front.Model;

public record DayPartWeatherModel
{
    public string Part { get; init; }
    public HourlyModel Data { get; init; }
}
