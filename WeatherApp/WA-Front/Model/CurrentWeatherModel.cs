using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Front.Model;

public class CurrentWeatherModel
{
    public float Temperature { get; init; }
    public float Rain { get; init; }
    public string ImageSource { get; init; }
    public float RealTemperature { get; init; }
}
