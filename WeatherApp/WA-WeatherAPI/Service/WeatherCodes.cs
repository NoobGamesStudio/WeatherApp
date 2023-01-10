using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_WeatherAPI.Service
{
    enum WeatherCodes
    {
        Clear_sky = 0,
        Mainly_clear = 1,
        Partly_cloudy = 2,
        Overcast = 3,
        Fog = 45,
        Deposing_rime_fog = 48,
        Light_drizzle = 51,
        Moderate_drizzle = 53,
        Dense_drizzle = 55,
        Light_freezing_drizzle = 56,
        Dense_freezing_drizzle = 57,
        Slight_rain = 61,
        Moderate_rain = 63,
        Heavy_rain = 65,
        Light_freezing_rain = 66,
        Heavy_freezing_rain = 67,
        Slight_snow_fall = 71,
        Moderate_snow_fall = 73,
        Heavy_snow_fall = 75,
        Snow_grains = 77,
        Slight_rain_showers = 80,
        Moderate_rain_showers = 81,
        Violent_rain_showers = 82,
        Slight_snow_showers = 85,
        Heavy_snow_showers = 86,
        Slightly_or_heavy_thunderstorm = 95,
        Thunderstorm_with_slight_and_heavy_hail = 96
    }
}
