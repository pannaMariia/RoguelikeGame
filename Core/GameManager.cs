using RoguelikeGame.Patterns.Observer;

namespace RoguelikeGame.Core;

public class GameManager
{
    private static GameManager? _instance;
    public static GameManager Instance => _instance ??= new GameManager();
    
    public Player? Player { get; set; }
    public GameObjectComposite Root { get; private set; }
    public bool HasKey { get; set; }
    public bool IsGameOver { get; private set; }
    
    private List<IGameObserver> _observers = new();
    
    private GameManager()
    {
        Root = new GameObjectComposite();
        HasKey = false;
        IsGameOver = false;
    }
    
    public void AddObserver(IGameObserver observer) => _observers.Add(observer);
    
    public void Notify(GameEvent gameEvent)
    {
        foreach (var observer in _observers)
            observer.OnNotify(gameEvent);
    }
    
    public void GameLose()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║               GAME OVER                ║");
        Console.WriteLine("║      You were killed by an enemy!      ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
        Environment.Exit(0);
    }
    
    public void GameWin()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║                VICTORY!                ║");
        Console.WriteLine("║      You escaped with the key!         ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
        Environment.Exit(0);
    }
    
    public void PickKey()
    {
        HasKey = true;
        Notify(new GameEvent(EventType.KeyPicked, "You found the key!"));
    }
}