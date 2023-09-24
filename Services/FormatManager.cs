using A3.Interfaces;

namespace A3.Services;

public class FormatManager : IFormatManager
{
    private readonly IRandomProvider _randomProvider;

    public FormatManager(IRandomProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public string FormatSecretCodeLine(string line, int maxLength)
    {
        var spacesCount = maxLength - (line.Length + 2);
        var firstSpacesCount = spacesCount / 2;
        var secondSpacesCount = spacesCount - firstSpacesCount;

        var firstSpaces = firstSpacesCount > 0
            ? string.Concat(Enumerable.Repeat(' ', firstSpacesCount))
            : string.Empty;

        var secondSpaces = secondSpacesCount > 0
            ? string.Concat(Enumerable.Repeat(' ', secondSpacesCount))
            : string.Empty;

        var randomNum = _randomProvider.GetRandomInt(0, Resources.Emojis.Length);
        return $"{Resources.Emojis[randomNum]}{firstSpaces}{line}{secondSpaces}{Resources.Emojis[randomNum]}";
    }
}
