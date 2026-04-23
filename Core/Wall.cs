namespace RoguelikeGame.Core;

public class Wall : IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsSolid => true;
    
    public Wall(int x, int y)
    {
        X = x;
        Y = y;
    }
}