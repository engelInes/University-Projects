using System;
using System.Collections.Generic;

public class CacheModule<T>
{
    readonly Dictionary<string, CacheItem<T>> _cache = new Dictionary<string, CacheItem<T>>();
    readonly object _lock = new object();
    public T Get(string key)
    {
        lock (_lock)
        {
            if (_cache.TryGetValue(key, out CacheItem<T> cacheItem))
            {
                if (!cacheItem.IsExpired())
                {
                    return cacheItem.Value;
                }
                else
                {
                    _cache.Remove(key);

                }
            }
            return default(T);
        }
    }
    public void Set(string key, T value, TimeSpan expirationTime)
    {
        lock (_lock)
        {
            var expirationTimeUtc = DateTime.UtcNow.Add(expirationTime);
            _cache[key] = new CacheItem<T>(value, expirationTimeUtc);
        }
    }
    public void Remove(string key)
    {
        lock (_lock)
        {
            _cache.Remove(key);
        }
    }
    public void Clear()
    {
        lock (_lock)
        {
            _cache.Clear();
        }
    }
    private class CacheItem<TValue>
    {
        public TValue Value { get; }
        public DateTime ExpirationTimeUtc { get; }

        public CacheItem(TValue value, DateTime expirationTimeUtc)
        {
            Value = value;
            ExpirationTimeUtc = expirationTimeUtc;
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow >= ExpirationTimeUtc;
        }
    }
}
/*
class Program
{
    static void Main(string[] args)
    {
        var cache = new CacheModule<string>();

        cache.Set("key1", "value1", TimeSpan.FromSeconds(5));

        string cachedData = cache.Get("key1");
        Console.WriteLine("Cached Data: " + cachedData);


        Console.WriteLine("Waiting for 3 seconds...");
        System.Threading.Thread.Sleep(3000);

        cachedData = cache.Get("key1");
        Console.WriteLine("Cached Data after 3 seconds: " + cachedData);

        Console.WriteLine("Waiting for 3 more seconds...");
        System.Threading.Thread.Sleep(3000);

        cachedData = cache.Get("key1");
        if (cachedData != null)
        {
            Console.WriteLine("Cached Data after 6 seconds: " + cachedData);

        }
        else
        { Console.WriteLine("Expiration time exceeded!"); }



        cache.Set("key1", "value1", TimeSpan.FromSeconds(5));
        cache.Set("key2", "value2", TimeSpan.FromSeconds(5));
        string cachedData1 = cache.Get("key1");
        string cachedData2 = cache.Get("key2");

        Console.WriteLine("Cached Data 1: " + cachedData1);
        Console.WriteLine("Cached Data 2: " + cachedData2);

        cache.Remove("key1");

        cachedData1 = cache.Get("key1");

        Console.WriteLine("Cached Data 1 after remove: " + cachedData1);
        Console.WriteLine("Cached Data 2 after remove: " + cachedData2);
        cache.Clear();
        string cachedDataFinal = cache.Get("key2");
        Console.WriteLine("Cached Data 2 after clear: " + cachedDataFinal);






    }
}
*/