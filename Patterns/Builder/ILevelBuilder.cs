using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;

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


