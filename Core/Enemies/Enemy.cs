namespace RoguelikeGame.Core.Enemies;

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



