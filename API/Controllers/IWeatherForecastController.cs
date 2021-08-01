namespace API.Controllers
{
    public interface IWeatherForecastController
    {
        IEnumerable<WeatherForecast> Get();
    }
}