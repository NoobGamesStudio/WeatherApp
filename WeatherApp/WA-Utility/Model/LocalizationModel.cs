namespace WA_Utility.Model;

public record Result
{
    public int id { get; set; }
    public string? name { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }

    public void Deconstruct(out double lon, out double lat) => (lon, lat) = (longitude, latitude);
}

public record Root
{
    public List<Result>? results { get; set; }
    public double generationtime_ms { get; set; }
}
