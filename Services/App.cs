using A3.Interfaces;

namespace A3.Services;

public class App : IApp
{
    private static readonly int _consoleColorMax = Enum.GetValues(typeof(ConsoleColor)).Length;

    private readonly IFormatManager _formatManager;

    public App(IFormatManager formatManager)
    {
        _formatManager = formatManager;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        Console.CursorVisible = false;

        var secretCodeArr = Resources.SecretCode.Split('\n');

        var curPos = new
        {
            Left = Console.WindowWidth / 2 - secretCodeArr[0].Length,
            Top = Console.WindowHeight / 2 - secretCodeArr.Length
        };

        var foregroundColor = ConsoleColor.Blue;
        var delay = 120;
        var maxLineLength = secretCodeArr.Max(l => l.Length) + 2;

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.SetCursorPosition(curPos.Left, curPos.Top);
            for (var i = 0; i < secretCodeArr.Length; i++)
            {
                DrawLine(secretCodeArr[i], maxLineLength, curPos.Left);
                ChangeColor(ref foregroundColor);
                await Task.Delay(delay, cancellationToken);
            }
        }
    }

    private void DrawLine(string line, int maxLength, int leftCursorPos)
    {
        line = _formatManager.FormatSecretCodeLine(line, maxLength);
        Console.WriteLine(line);
        Console.CursorLeft = leftCursorPos;
    }

    private static void ChangeColor(ref ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = foregroundColor;
        foregroundColor = (ConsoleColor)(((int)foregroundColor + 1) % _consoleColorMax);
        if (foregroundColor == Console.BackgroundColor) foregroundColor++;
    }
}
