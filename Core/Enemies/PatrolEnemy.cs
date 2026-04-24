namespace RoguelikeGame.Core.Enemies;

public class PatrolEnemy : Enemy
{
    private int _step;
    private int _direction = 1;
    
    public PatrolEnemy(int x, int y) : base(x, y) { }
    
    public override void Update(GameManager gm)
    {
        _step++;
        if (_step % 30 == 0)
        {
            int newX = X + _direction;
            if (newX >= 0 && newX < 20)
            {
                var solid = gm.Root.GetAt(newX, Y);
                if (solid == null && !gm.Root.IsEnemyAt(newX, Y))
                    X = newX;
                else
                    _direction *= -1;
            }
            else
                _direction *= -1;
        }
    }
}