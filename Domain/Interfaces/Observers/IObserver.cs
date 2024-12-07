namespace PatterObserver.Domain.Interfaces.Observers;

public interface IObserver
{
    void Update(ISubject subject);

}
