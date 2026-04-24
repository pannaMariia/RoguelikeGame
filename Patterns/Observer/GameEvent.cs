namespace RoguelikeGame.Patterns.Observer;
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