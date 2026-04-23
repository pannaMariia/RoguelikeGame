using RoguelikeGame.Core;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Interpreter;

public interface ICommand
{
    void Execute(GameManager gm, Level level);
}

public class WallCommand : ICommand
{
    private int _x, _y;
    public WallCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Walls.Add(new Wall(_x, _y));
}

public class PlayerCommand : ICommand
{
    private int _x, _y;
    public PlayerCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Player = new Player(_x, _y, gm);
}

public class KeyCommand : ICommand
{
    private int _x, _y;
    public KeyCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Key = new Key(_x, _y);
}

public class DoorCommand : ICommand
{
    private int _x, _y;
    public DoorCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Door = new Door(_x, _y);
}

public class EnemyCommand : ICommand
{
    private string _type;
    private int _x, _y;
    
    public EnemyCommand(string type, int x, int y)
    {
        _type = type;
        _x = x;
        _y = y;
    }
    
    public void Execute(GameManager gm, Level level)
    {
        if (_type == "RANDOM")
            level.Enemies.Add(new RandomEnemy(_x, _y));
        else if (_type == "PATROL")
            level.Enemies.Add(new PatrolEnemy(_x, _y));
    }
}

public class LevelParser
{
    public Level Parse(string filename)
    {
        var level = new Level();
        if (!File.Exists(filename))
            return level;
            
        var lines = File.ReadAllLines(filename);
        
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                continue;
                
            var parts = line.Split(' ');
            if (parts.Length < 2) continue;
            
            ICommand? command = null;
            
            switch (parts[0].ToUpper())
            {
                case "WALL":
                    var wallCoords = parts[1].Split(',');
                    command = new WallCommand(int.Parse(wallCoords[0]), int.Parse(wallCoords[1]));
                    break;
                case "PLAYER":
                    var playerCoords = parts[1].Split(',');
                    command = new PlayerCommand(int.Parse(playerCoords[0]), int.Parse(playerCoords[1]));
                    break;
                case "KEY":
                    var keyCoords = parts[1].Split(',');
                    command = new KeyCommand(int.Parse(keyCoords[0]), int.Parse(keyCoords[1]));
                    break;
                case "DOOR":
                    var doorCoords = parts[1].Split(',');
                    command = new DoorCommand(int.Parse(doorCoords[0]), int.Parse(doorCoords[1]));
                    break;
                case "ENEMY":
                    var enemyParts = parts[1].Split(',');
                    command = new EnemyCommand(enemyParts[0], int.Parse(enemyParts[1]), int.Parse(enemyParts[2]));
                    break;
            }
            
            command?.Execute(GameManager.Instance, level);
        }
        
        return level;
    }
}
