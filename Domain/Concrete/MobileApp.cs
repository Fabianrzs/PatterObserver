using PatterObserver.Domain.Interfaces;

namespace PatterObserver.Domain.Concrete;

public class MobileApp : IWeatherObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"[Mobile App] Weather Update: Temp={temperature}°C, Humidity={humidity}%, Pressure={pressure}hPa");
    }
}