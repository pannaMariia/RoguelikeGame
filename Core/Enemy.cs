namespace RoguelikeGame.Core;

public abstract class Enemy : IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsSolid => true;
    
    protected Random _rand = new();
    
    public Enemy(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public abstract void Update(GameManager gm);
}

public class RandomEnemy : Enemy
{
    public RandomEnemy(int x, int y) : base(x, y) { }
    
    public override void Update(GameManager gm)
    {
        var dirs = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        int idx = _rand.Next(dirs.Length);
        int dx = dirs[idx].Item1;
        int dy = dirs[idx].Item2;
        
        int newX = X + dx;
        int newY = Y + dy;
        
        if (newX >= 0 && newX < 20 && newY >= 0 && newY < 20)
        {
            var solid = gm.Root.GetAt(newX, newY);
            if (solid == null && !gm.Root.IsEnemyAt(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
    }
}

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