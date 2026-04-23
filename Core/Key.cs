namespace RoguelikeGame.Core;

public class Key : IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsSolid => false;
    
    public Key(int x, int y)
    {
        X = x;
        Y = y;
    }
}