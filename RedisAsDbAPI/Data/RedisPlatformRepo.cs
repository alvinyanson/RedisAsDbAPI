using RedisAsDbAPI.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisAsDbAPI.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;

        private readonly IDatabase _db;

        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;

            _db = _redis.GetDatabase();
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            var serializedPlatform = JsonSerializer.Serialize(platform);

            //_db.StringSet(platform.Id, serializedPlatform);

            //_db.SetAdd("PlatformSet", serializedPlatform);

            _db.HashSet("HashPlatform", new HashEntry[] { new HashEntry(platform.Id, serializedPlatform) });
        }

        public IEnumerable<Platform>? GetAllPlatforms()
        {
            //var completeSet = _db.SetMembers("PlatformSet");

            var completeSet = _db.HashGetAll("HashPlatform");

            if (completeSet.Length > 0)
            {
                var obj = completeSet
                    .Select(x => JsonSerializer.Deserialize<Platform>(x.Value!))
                    .ToList();

                return obj!;
            }

            return null;
        }

        public Platform? GetPlatformById(string id)
        {
            //var platform = _db.StringGet(id);

            var platform = _db.HashGet("HashPlatform", id);

            if (!string.IsNullOrEmpty(platform))
            {
                return JsonSerializer.Deserialize<Platform>(platform!)!;
            }

            return null;
        }
    }
}
