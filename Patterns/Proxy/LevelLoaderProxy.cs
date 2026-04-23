using RoguelikeGame.Core;
using RoguelikeGame.Patterns.Builder;

namespace RoguelikeGame.Patterns.Proxy;

public class LevelLoaderProxy
{
    private Level? _cachedLevel;
    private string _levelFile;
    private bool _isLoaded = false;
    
    public LevelLoaderProxy(string levelFile)
    {
        _levelFile = levelFile;
    }
    
    public Level Load()
    {
        if (!_isLoaded)
        {
            Console.WriteLine("[Proxy] Loading level for first time...");
            
            var builder = new SimpleLevelBuilder();
            var director = new LevelDirector();
            director.Construct(builder);
            _cachedLevel = builder.GetResult();
            _isLoaded = true;
        }
        else
        {
            Console.WriteLine("[Proxy] Returning cached level...");
        }
        
        return _cachedLevel!;
    }
}
