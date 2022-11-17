using Microsoft.Extensions.Caching.Distributed;

namespace HealthCare.Appointments.Api.Service
{
    public interface ICacheProvider
    {
        Task ClearCache(string key);
        Task<T> GetFromCache<T>(string key) where T : class;
        Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;
    }
}
