namespace WA_WeatherAPI.Interface;

internal interface ICastable<T>
{
    List<T> Cast();
}
