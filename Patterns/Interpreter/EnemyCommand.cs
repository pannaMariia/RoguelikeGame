using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Interpreter;

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
