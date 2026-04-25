using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;

namespace RoguelikeGame.Patterns.Builder;

public class LevelDirector
{
    public void Construct(ILevelBuilder builder)
    {
        // порядок
        builder.Reset();
        builder.BuildWalls();
        builder.BuildDoor();
        builder.BuildKey();
        builder.BuildEnemies();
        builder.BuildPlayer();
    }
}