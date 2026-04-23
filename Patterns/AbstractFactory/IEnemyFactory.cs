using RoguelikeGame.Core;

namespace RoguelikeGame.Patterns.AbstractFactory;

public interface IEnemyFactory
{
    Enemy CreateEnemy(int x, int y);
}

public class RandomEnemyFactory : IEnemyFactory
{
    public Enemy CreateEnemy(int x, int y) => new RandomEnemy(x, y);
}

public class PatrolEnemyFactory : IEnemyFactory
{
    public Enemy CreateEnemy(int x, int y) => new PatrolEnemy(x, y);
}
