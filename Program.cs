using RoguelikeGame.Core;
using RoguelikeGame.Patterns.Proxy;
using RoguelikeGame.Patterns.Observer;
using System.Text;

namespace RoguelikeGame;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Roguelike Dungeon";
        Console.CursorVisible = false;
        
        try
        {
            Console.SetWindowSize(60, 35);
            Console.SetBufferSize(60, 35);
        }
        catch { }
        
        var gm = GameManager.Instance;
        gm.AddObserver(new UIObserver());
        
        var levelProxy = new LevelLoaderProxy("Levels/level1.txt");
        var level = levelProxy.Load();
        level.Setup(gm);
        
        while (!gm.IsGameOver)
        {
            Console.Clear();
            
            DrawHeader();
            DrawStatus(gm);
            DrawGameField(gm);
            DrawControls();
            
            var key = Console.ReadKey(true).Key;
            int dx = 0, dy = 0;
            
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    dy = -1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    dy = 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    dx = -1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    dx = 1;
                    break;
                case ConsoleKey.Escape:
                    return;
            }
            
            if (dx != 0 || dy != 0)
            {
                gm.Player?.Move(dx, dy);
            }
            
            foreach (var obj in gm.Root.GetChildren())
            {
                if (obj is Enemy enemy)
                    enemy.Update(gm);
            }
        }
    }
    
    static void DrawHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    ROGUELIKE DUNGEON                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    static void DrawStatus(GameManager gm)
    {
        Console.ForegroundColor = gm.HasKey ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine($"  KEY: {(gm.HasKey ? "✓ FOUND" : "✗ MISSING")}");
        Console.ResetColor();
        
        if (gm.Player != null)
        {
            Console.WriteLine($"  POS: ({gm.Player.X}, {gm.Player.Y})");
        }
        Console.WriteLine();
    }
    
    static void DrawGameField(GameManager gm)
    {
        // Сохраняем позицию курсора для отрисовки поля
        int startY = Console.CursorTop;
        
        // Рисуем сетку 20x20
        for (int y = 0; y < 20; y++)
        {
            Console.Write("  "); // Отступ слева
            for (int x = 0; x < 20; x++)
            {
                var obj = gm.Root.GetAnyAt(x, y);
                if (obj is Player && gm.Player != null && gm.Player.X == x && gm.Player.Y == y)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write('P');
                }
                else if (obj is Wall)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write('#');
                }
                else if (obj is Enemy)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('E');
                }
                else if (obj is Key)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('K');
                }
                else if (obj is Door)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write('D');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('.');
                }
                Console.ResetColor();
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
    
    static void DrawControls()
    {
        Console.WriteLine();
        Console.WriteLine("  ┌─────────────────────────────────────────────────────┐");
        Console.WriteLine("  │  CONTROLS:  W/A/S/D  or  ↑/←/↓/→      ESC = exit   │");
        Console.WriteLine("  └─────────────────────────────────────────────────────┘");
    }
}