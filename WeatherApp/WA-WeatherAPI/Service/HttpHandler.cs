using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WA_WeatherAPI.Model.Current;
using WA_WeatherAPI.Model.Daily;
using WA_WeatherAPI.Model.Hourly;

namespace WA_WeatherAPI.Service
{
    public class HttpHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherCodes _weathercodes;
        private readonly double latitude = 53.43;
        private readonly double longitude = 14.55;

        public HttpHandler(IHttpClientFactory httpClientFactory, double latitude, double longitude)
        {
            _httpClientFactory = httpClientFactory;
            //_latitude = latitude;
            //_longitude = longitude;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public async Task Forecast()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var currResponse = await httpClient.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&timezone=auto&current_weather=true");
            var hResponse = await httpClient.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&timezone=auto&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,precipitation,weathercode,surface_pressure,cloudcover,visibility");
            var dResponse = await httpClient.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&timezone=auto&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_sum,precipitation_hours,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant,shortwave_radiation_sum");

            var currentForecast = Current.FromJson(currResponse);
            var hourlyForecast = Hourly.FromJson(hResponse);
            var dailyForecast = Daily.FromJson(dResponse);

            if (currentForecast != null)
            {
                Console.WriteLine($"Timezone: {currentForecast.Timezone} \nTime: {currentForecast.CurrentWeather.Time} \nTemperature: {currentForecast.CurrentWeather.Temperature} \nWindspeed: {currentForecast.CurrentWeather.Windspeed} \nWind direction: {currentForecast.CurrentWeather.Winddirection} \nWeathercode: {currentForecast.CurrentWeather.Weathercode}");
            }
            else if (hourlyForecast != null)
            {
                Console.WriteLine($"Timezone: {hourlyForecast.Timezone} \nTime: {hourlyForecast.HourlyWeather.Time} \nTemperature: {hourlyForecast.HourlyWeather.Temperature2M} \nReal feel: {hourlyForecast.HourlyWeather.ApparentTemperature} \n Humidity: {hourlyForecast.HourlyWeather.Relativehumidity2M} \nPrecipitation: {hourlyForecast.HourlyWeather.Precipitation} \nSurface pressure: {hourlyForecast.HourlyWeather.SurfacePressure} \nCloudcover: {hourlyForecast.HourlyWeather.Cloudcover} \nVisibility: {hourlyForecast.HourlyWeather.Visibility} \nWeathercode: {hourlyForecast.HourlyWeather.Weathercode}");
            }
            else if (dailyForecast != null)
            {
                Console.WriteLine($"Timezone: {dailyForecast.Timezone} \nTime: {dailyForecast.DailyWeather.Time} \nMin temperature: {dailyForecast.DailyWeather.Temperature2MMin} \nMax Temperature: {dailyForecast.DailyWeather.Temperature2MMax} \nSunrise: {dailyForecast.DailyWeather.Sunrise} \nSunset: {dailyForecast.DailyWeather.Sunset} \nSummary precipitation: {dailyForecast.DailyWeather.PrecipitationSum} \nHourly precipitation: {dailyForecast.DailyWeather.PrecipitationHours} \nMax windspeed: {dailyForecast.DailyWeather.Windspeed10MMax} \nMax windgusts: {dailyForecast.DailyWeather.Windgusts10MMax} \nDominant wind direction: {dailyForecast.DailyWeather.Winddirection10MDominant} \nShortwave summary radiation: {dailyForecast.DailyWeather.ShortwaveRadiationSum} \nWeathercode: {dailyForecast.DailyWeather.Weathercode}");
            }
            else if (currentForecast == null || hourlyForecast == null || dailyForecast == null)
            {
                Console.WriteLine("ERROR!");
                return;
            }
        }
    }
}
