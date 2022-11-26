namespace WA_WeatherAPI.Model;

internal interface IExampleModelInterface
{
    // accessors (declaring getter is minimum)
    int Id { get; }
    string Name { get; set; }

    // delegates (mainly for events)
    delegate void IntDelegate(int value);

    // events (should be declared with Action/Func/Predicate)
    event IntDelegate IntEvent;
    event Action<int> IntActionEvent;
    event Func<int, double> IntFuncEvent; 
    // Func<T, bool> is equivalent to Predicate<T> 
    event Predicate<int> IntPredicateEvent;
}