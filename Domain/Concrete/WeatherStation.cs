using PatterObserver.Domain.Interfaces;

namespace PatterObserver.Domain.Concrete;
public class WeatherStation : IWeatherStation
{
    private readonly List<IWeatherObserver> observers = [];
    
    
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        Notify();
    }
    public void GetAllObservers() => observers.ForEach(observer => Console.WriteLine(observer));
    public void Attach(IWeatherObserver observer) => observers.Add(observer);
    public void Detach(IWeatherObserver observer) => observers.Remove(observer);
    public void Notify()
    {
        foreach (var observer in observers)
        {
            Thread.Sleep(1000);
            observer.Update(_temperature, _humidity, _pressure);
            Console.ReadKey();

        }
    }
}

