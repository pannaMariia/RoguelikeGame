namespace RoguelikeGame.Core;

public interface IGameObject
{
    int X { get; set; }
    int Y { get; set; }
    bool IsSolid { get; }
}