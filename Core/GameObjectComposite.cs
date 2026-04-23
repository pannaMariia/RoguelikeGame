namespace RoguelikeGame.Core;

public class GameObjectComposite
{
    private List<IGameObject> _children = new();
    
    public void Add(IGameObject obj) => _children.Add(obj);
    public void Remove(IGameObject obj) => _children.Remove(obj);
    public List<IGameObject> GetChildren() => _children;
    
    public IGameObject? GetAt(int x, int y) 
    {
        return _children.FirstOrDefault(obj => obj.X == x && obj.Y == y && obj.IsSolid);
    }
    
    public IGameObject? GetAnyAt(int x, int y) 
    {
        return _children.FirstOrDefault(obj => obj.X == x && obj.Y == y);
    }
    
    public bool IsEnemyAt(int x, int y) 
    {
        return _children.Any(obj => obj.X == x && obj.Y == y && obj is Enemy);
    }
    
    public void Clear() => _children.Clear();
}