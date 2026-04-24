using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Interpreter;

public class PlayerCommand : ICommand
{
    private int _x, _y;
    public PlayerCommand(int x, int y) { _x = x; _y = y; }
    public void Execute(GameManager gm, Level level) => level.Player = new Player(_x, _y, gm);
}