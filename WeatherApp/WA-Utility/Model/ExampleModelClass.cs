namespace WA_Utility.Model;

public class ExampleModelClass
{
    // static instance shared across instances
    private static int _id;

    // static constructor (for static initialization)
    static ExampleModelClass() => _id = 0;

    // parameterless constructor
    public ExampleModelClass() => Id = _id++;

    // single parameter constructor
    public ExampleModelClass(string name) : this() => Name = name;

    // accessors
    public int Id
    {
        get; // getter  
    }
    public string Name
    {
        get; // getter
        init; // init setter (value can be set only at construction phase)
    } = "";
}