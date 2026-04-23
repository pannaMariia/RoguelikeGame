namespace RoguelikeGame.Core;

public class Door : IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsSolid => false;
    
    public Door(int x, int y)
    {
        X = x;
        Y = y;
    }
}