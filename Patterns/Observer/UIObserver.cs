namespace RoguelikeGame.Patterns.Observer;
public class UIObserver : IGameObserver
{
    public void OnNotify(GameEvent gameEvent)
    {
        Console.SetCursorPosition(0, 8);
        Console.ForegroundColor = gameEvent.Type switch
        {
            EventType.KeyPicked => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
        Console.WriteLine(new string(' ', 60));
        Console.SetCursorPosition(0, 8);
        Console.WriteLine($"  {gameEvent.Message}");
        Console.ResetColor();
        
        Thread.Sleep(800);
    }
}