using RoguelikeGame.Core;
using RoguelikeGame.Core.Enemies;

namespace RoguelikeGame.Patterns.AbstractFactory;

public interface IEnemyFactory
{
    Enemy CreateEnemy(int x, int y);
}

