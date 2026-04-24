using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;

namespace RoguelikeGame.Patterns.AbstractFactory;

public class PatrolEnemyFactory : IEnemyFactory
{
    public Enemy CreateEnemy(int x, int y) => new PatrolEnemy(x, y);
}
