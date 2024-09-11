using RedisAsDbAPI.Models;

namespace RedisAsDbAPI.Data
{
    public interface IPlatformRepo
    {
        IEnumerable<Platform>? GetAllPlatforms();
        
        void CreatePlatform(Platform platform);
        
        Platform? GetPlatformById(string id);
    }
}
