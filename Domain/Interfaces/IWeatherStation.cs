namespace PatterObserver.Domain.Interfaces;

public interface IWeatherStation
{
    void Attach(IWeatherObserver observer);
    void Detach(IWeatherObserver observer);
    void Notify();
}
