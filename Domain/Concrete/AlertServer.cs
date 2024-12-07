using PatterObserver.Domain.Interfaces;

namespace PatterObserver.Domain.Concrete;

public class AlertServer : IWeatherObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        if (temperature > 40)
        {
            Console.WriteLine($"[Alert Server] Critical Alert: Extreme heat! Temp={temperature}°C");
        }

        if (pressure < 1000)
        {
            Console.WriteLine($"[Alert Server] Critical Alert: Low pressure! Pressure={pressure}hPa");
        }
    }
}

