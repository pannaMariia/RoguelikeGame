namespace RoguelikeGame.Patterns.Observer;

public enum EventType
{
    KeyPicked,
    GameWin,
    GameLose
}

public class GameEvent
{
    public EventType Type { get; }
    public string Message { get; }
    
    public GameEvent(EventType type, string message)
    {
        Type = type;
        Message = message;
    }
}

public interface IGameObserver
{
    void OnNotify(GameEvent gameEvent);
}

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