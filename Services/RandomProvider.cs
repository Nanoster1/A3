using A3.Interfaces;

namespace A3.Services;

public class RandomProvider : IRandomProvider
{
    private readonly Random _random = new();

    public int GetRandomInt(int min, int max)
    {
        return _random.Next(min, max);
    }
}
