using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Interpreter;

public class LevelParser
{
    public Level Parse(string filename)
    {
        var level = new Level();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine($"[Parser] File not found: {filename}");
            return level;
        }
        
        var lines = File.ReadAllLines(filename);
        
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//"))
                continue;
                
            var parts = line.Trim().Split(' ');
            if (parts.Length < 2) continue;
            
            ICommand? command = null;
            
            try
            {
                switch (parts[0].ToUpper())
                {
                    case "WALL":
                        var wallCoords = parts[1].Split(',');
                        int wallX = int.Parse(wallCoords[0]);
                        int wallY = int.Parse(wallCoords[1]);
                        command = new WallCommand(wallX, wallY);
                        Console.WriteLine($"[Parser] Added wall at ({wallX}, {wallY})");
                        break;
                        
                    case "PLAYER":
                        var playerCoords = parts[1].Split(',');
                        command = new PlayerCommand(
                            int.Parse(playerCoords[0]), 
                            int.Parse(playerCoords[1])
                        );
                        break;
                        
                    case "KEY":
                        var keyCoords = parts[1].Split(',');
                        command = new KeyCommand(
                            int.Parse(keyCoords[0]), 
                            int.Parse(keyCoords[1])
                        );
                        break;
                        
                    case "DOOR":
                        var doorCoords = parts[1].Split(',');
                        command = new DoorCommand(
                            int.Parse(doorCoords[0]), 
                            int.Parse(doorCoords[1])
                        );
                        break;
                        
                    case "ENEMY":
                        var enemyParts = parts[1].Split(',');
                        string enemyType = enemyParts[0];
                        int enemyX = int.Parse(enemyParts[1]);
                        int enemyY = int.Parse(enemyParts[2]);
                        command = new EnemyCommand(enemyType, enemyX, enemyY);
                        break;
                }
                
                command?.Execute(GameManager.Instance, level);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Parser] Error parsing line: {line}");
                Console.WriteLine($"[Parser] {ex.Message}");
            }
        }
        
        Console.WriteLine($"[Parser] Loaded: {level.Walls.Count} walls, {level.Enemies.Count} enemies");
        return level;
    }
}