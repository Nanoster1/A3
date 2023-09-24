namespace A3.Interfaces;

public interface IApp
{
    Task Run(CancellationToken cancellationToken);
}
