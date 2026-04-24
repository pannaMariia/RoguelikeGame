using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Interpreter;

public class DoorCommand : ICommand
{
    private int _x, _y;
    public DoorCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Door = new Door(_x, _y);
}
