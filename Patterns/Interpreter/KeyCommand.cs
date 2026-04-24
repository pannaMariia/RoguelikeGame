using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Interpreter;

public class KeyCommand : ICommand
{
    private int _x, _y;
    public KeyCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Key = new Key(_x, _y);
}