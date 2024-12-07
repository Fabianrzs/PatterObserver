namespace PatterObserver.Domain.Interfaces;

public interface IWeatherObserver
{
    void Update(float temperature, float humidity, float pressure);
}
