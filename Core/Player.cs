namespace RoguelikeGame.Core;

public class Player : IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsSolid => false;
    
    private GameManager _gm;
    
    public Player(int startX, int startY, GameManager gm)
    {
        X = startX;
        Y = startY;
        _gm = gm;
    }
    
    public void Move(int dx, int dy)
    {
        int newX = X + dx;
        int newY = Y + dy;
        
        if (newX < 0 || newX > 19 || newY < 0 || newY > 19)
            return;
        
        if (_gm.Root.IsEnemyAt(newX, newY))
        {
            _gm.GameLose();
            return;
        }
        
        var solidObj = _gm.Root.GetAt(newX, newY);
        if (solidObj != null && solidObj.IsSolid)
            return;
        
        var objAt = _gm.Root.GetAnyAt(newX, newY);
        if (objAt is Door)
        {
            if (_gm.HasKey)
                _gm.GameWin();
            return;
        }
        
        if (objAt is Key)
        {
            _gm.PickKey();
            _gm.Root.Remove(objAt);
        }
        
        X = newX;
        Y = newY;
    }
}