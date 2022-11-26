namespace WA_WeatherAPI.Model;

// single parameter constructor
public record ExampleModelRecord(string Name)
{
    // static instance shared across instances
    private static int _id;

    // static constructor (for static initialization)
    static ExampleModelRecord() => _id = 0;

    // parameterless constructor
    public ExampleModelRecord(): this("") => Id = _id++;

    // accessors
    public int Id 
    { 
        get; // getter  
    }
}
