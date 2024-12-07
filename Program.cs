using PatterObserver.Domain.Concrete;
using PatterObserver.Domain.Interfaces;

WeatherStation weatherStation = new();

MobileApp mobileApp = new();
ControlPanel controlPanel = new();
AlertServer alertServer = new();

bool exit = false;

var availableObservers = new Dictionary<int, IWeatherObserver>
{
    { 1, mobileApp },
    { 2, controlPanel },
    { 3, alertServer }
};

while (!exit)
{
    ShowMenu();

    Action? action = Console.ReadLine() switch
    {
        "1" => SetWeatherMeasurements,
        "2" => AttachObserver,
        "3" => DetachObserver,
        "4" => ShowAllObservers,
        "5" => () => { exit = true; Console.WriteLine("Exiting program..."); },
        _ => () => Console.WriteLine("Invalid option, try again!")
    };

    action?.Invoke();
}

void ShowMenu()
{
    Console.Clear();
    Thread.Sleep(1000);
    Console.WriteLine("\n=== Weather Station Menu ===");
    Console.WriteLine("1. Set Weather Measurements");
    Console.WriteLine("2. Attach Observer");
    Console.WriteLine("3. Detach Observer");
    Console.WriteLine("4. Get All Observer");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
}

void SetWeatherMeasurements()
{
    Console.Write("Enter Temperature (°C): ");
    float temp = float.Parse(Console.ReadLine() ?? "0");

    Console.Write("Enter Humidity (%): ");
    float humidity = float.Parse(Console.ReadLine() ?? "0");

    Console.Write("Enter Pressure (hPa): ");
    float pressure = float.Parse(Console.ReadLine() ?? "0");

    weatherStation.SetMeasurements(temp, humidity, pressure);
    Console.WriteLine("Weather measurements updated!");
    Console.WriteLine();
}

void AttachObserver()
{
    Console.WriteLine("\nAvailable Observers:");
    foreach (var observerItem in availableObservers)
    {
        Console.WriteLine($"{observerItem.Key}. {observerItem.Value.GetType().Name}");
    }
    Console.Write("Choose an observer to attach: ");

    if (int.TryParse(Console.ReadLine(), out int attachChoice) && availableObservers.TryGetValue(attachChoice, out IWeatherObserver? observer))
    {
        weatherStation.Attach(observer);
        Console.WriteLine($"{observer.GetType().Name} attached successfully!");
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}

void DetachObserver()
{
    Console.WriteLine("\nAvailable Observers:");
    foreach (var observerItem in availableObservers)
    {
        Console.WriteLine($"{observerItem.Key}. {observerItem.Value.GetType().Name}");
    }
    Console.Write("Choose an observer to detach: ");

    if (int.TryParse(Console.ReadLine(), out int detachChoice) && availableObservers.TryGetValue(detachChoice, out IWeatherObserver? observer))
    {
        weatherStation.Detach(observer);
        Console.WriteLine($"{observer.GetType().Name} detached successfully!");
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}

void ShowAllObservers()
{
    Console.WriteLine("\nAll Observers:");
    weatherStation.GetAllObservers();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}