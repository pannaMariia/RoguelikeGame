namespace RoguelikeGame.Patterns.Observer;


public interface IGameObserver
{
    void OnNotify(GameEvent gameEvent);
}

