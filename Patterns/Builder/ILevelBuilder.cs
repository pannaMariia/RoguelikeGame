using RoguelikeGame.Core;

namespace RoguelikeGame.Patterns.Builder;

public interface ILevelBuilder
{
    void Reset();
    void BuildWalls();
    void BuildPlayer();
    void BuildKey();
    void BuildEnemies();
    void BuildDoor();
    Level GetResult();
}

public class Level
{
    public List<Wall> Walls { get; set; } = new();
    public Player? Player { get; set; }
    public Key? Key { get; set; }
    public List<Enemy> Enemies { get; set; } = new();
    public Door? Door { get; set; }
    
    public void Setup(GameManager gm)
    {
        gm.Root.Clear();
        
        foreach (var wall in Walls)
            gm.Root.Add(wall);
        
        if (Door != null)
            gm.Root.Add(Door);
        
        if (Key != null)
            gm.Root.Add(Key);
        
        foreach (var enemy in Enemies)
            gm.Root.Add(enemy);
        
        gm.Player = Player;
        if (Player != null)
            gm.Root.Add(Player);
    }
}

public class SimpleLevelBuilder : ILevelBuilder
{
    private Level _level = new();
    
    public void Reset() => _level = new Level();
    
    public void BuildWalls()
    {
        // Только внешние стены (уберем внутренний лабиринт для видимости)
        for (int i = 0; i < 20; i++)
        {
            _level.Walls.Add(new Wall(i, 0));
            _level.Walls.Add(new Wall(i, 19));
            _level.Walls.Add(new Wall(0, i));
            _level.Walls.Add(new Wall(19, i));
        }
        
        // Небольшие препятствия внутри
        for (int i = 5; i < 10; i++)
        {
            _level.Walls.Add(new Wall(10, i));
        }
        for (int i = 10; i < 15; i++)
        {
            _level.Walls.Add(new Wall(5, i));
        }
    }
    
    public void BuildPlayer()
    {
        _level.Player = new Player(2, 2, GameManager.Instance);
    }
    
    public void BuildKey()
    {
        _level.Key = new Key(17, 17);
    }
    
    public void BuildDoor()
    {
        _level.Door = new Door(1, 1);
    }
    
    public void BuildEnemies()
    {
        _level.Enemies.Add(new RandomEnemy(5, 5));
        _level.Enemies.Add(new RandomEnemy(14, 5));
        _level.Enemies.Add(new PatrolEnemy(3, 12));
        _level.Enemies.Add(new PatrolEnemy(15, 15));
    }
    
    public Level GetResult() => _level;
}

public class LevelDirector
{
    public void Construct(ILevelBuilder builder)
    {
        builder.Reset();
        builder.BuildWalls();
        builder.BuildDoor();
        builder.BuildKey();
        builder.BuildEnemies();
        builder.BuildPlayer();
    }
}