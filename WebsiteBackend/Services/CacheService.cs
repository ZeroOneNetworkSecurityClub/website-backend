using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;

namespace WebsiteBackend.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _redisDb;
        private readonly string _instanceName;
        private readonly TimeSpan _defaultCacheTime;
        
        public CacheService(IConnectionMultiplexer redisConnection, IConfiguration configuration)
        {
            _redisDb = redisConnection.GetDatabase();
            _instanceName = configuration["Redis:InstanceName"] ?? "WebsiteBackend:";
            _defaultCacheTime = TimeSpan.FromSeconds(Convert.ToDouble(configuration["Redis:DefaultCacheTime"] ?? "3600"));
        }
        
        public async Task<T?> GetAsync<T>(string key)
        {
            var fullKey = $"{_instanceName}{key}";
            var value = await _redisDb.StringGetAsync(fullKey);
            
            if (value.IsNull)
            {
                return default;
            }
            
            return JsonSerializer.Deserialize<T>(value);
        }
        
        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var fullKey = $"{_instanceName}{key}";
            var jsonValue = JsonSerializer.Serialize(value);
            
            await _redisDb.StringSetAsync(fullKey, jsonValue, expiry ?? _defaultCacheTime);
        }
        
        public async Task RemoveAsync(string key)
        {
            var fullKey = $"{_instanceName}{key}";
            await _redisDb.KeyDeleteAsync(fullKey);
        }
        
        public async Task<bool> ExistsAsync(string key)
        {
            var fullKey = $"{_instanceName}{key}";
            return await _redisDb.KeyExistsAsync(fullKey);
        }
        
        public async Task RemoveByPatternAsync(string pattern)
        {
            var server = _redisDb.Multiplexer.GetServer(_redisDb.Multiplexer.GetEndPoints().First());
            var keys = server.Keys(pattern: $"{_instanceName}{pattern}");
            
            if (keys.Any())
            {
                await _redisDb.KeyDeleteAsync(keys.ToArray());
            }
        }
    }
}