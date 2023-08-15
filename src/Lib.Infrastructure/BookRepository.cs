using lib.Domain;
using Lib.Application;
using Lib.Application.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lib.Infrastructure
{
    internal class BookRepository : IBookRepository
    {
        private readonly IDistributedCache _redisCache;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(IDistributedCache redisCache, IMemoryCache memoryCache, IHttpClientFactory httpClientFactory, ILogger<BookRepository> logger)
        {
            _redisCache = redisCache;
            _memoryCache = memoryCache;
            _httpClientFactory = httpClientFactory;
            _logger = logger;

        }

        public async Task<bookDto> GetBookAsync(int id)
        {
            // Check Redis cache
            var redisKey = $"book_{id}";
            bool isRedisOnline = true;
            try
            {
                var redisValue = await _redisCache.GetStringAsync(redisKey);
                if (redisValue != null)
                {
                    var rbook = JsonConvert.DeserializeObject<bookDto>(redisValue);
                    return rbook;
                }
            }
            catch (Exception ex)
            {
                isRedisOnline = false;
                _logger.LogInformation("redis server is not available");

            }


            // Check Memory cache
            if (_memoryCache.TryGetValue(redisKey, out bookDto cachedBook))
            {
                return cachedBook;
            }

            // Fetch data from external API
            var apiUrl = $"https://get.taaghche.com/v2/book/{id}";
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var bookData = JsonConvert.DeserializeObject<BookData>(responseContent);

            // Store data in Redis and Memory caches
            var book = bookData.book;
            if(isRedisOnline)
            {
                var cacheOptions = new DistributedCacheEntryOptions()
              .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                await _redisCache.SetStringAsync(redisKey, JsonConvert.SerializeObject(book), cacheOptions);
            }
           

            var memocacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
            _memoryCache.Set(redisKey, book, memocacheOptions);

            return book;
        }


    }
}
