using PatterObserver.Domain.Interfaces;

namespace PatterObserver.Domain.Concrete;

public class ControlPanel : IWeatherObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        if (temperature > 35)
        {
            Console.WriteLine($"[Control Panel] Warning: High temperature detected! Temp={temperature}°C");
        }
        else if (humidity < 20)
        {
            Console.WriteLine($"[Control Panel] Warning: Low humidity detected! Humidity={humidity}%");
        }
    }
}
