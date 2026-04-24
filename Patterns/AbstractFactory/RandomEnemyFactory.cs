using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;
namespace RoguelikeGame.Patterns.AbstractFactory;

public class RandomEnemyFactory : IEnemyFactory
{
    public Enemy CreateEnemy(int x, int y) => new RandomEnemy(x, y);
}