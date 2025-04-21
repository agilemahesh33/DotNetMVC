using HackerNewsApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsApi.Services
{
    public class HackerNewsService : IHackerNewsService
    {        
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;
        public HackerNewsService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }
        public async Task<List<StoryDto>> GetNewestStoriesAsync(int page = 1, int pageSize = 20)
        {
            const string newStoriesUrl = "https://hacker-news.firebaseio.com/v0/newstories.json";
            var client = _httpClientFactory.CreateClient();

            if (!_cache.TryGetValue("newStories", out List<int> storyIds))
            {
                var idsResponse = await client.GetFromJsonAsync<List<int>>(newStoriesUrl);
                if (idsResponse == null)
                    return new();
                storyIds = idsResponse;
                _cache.Set("newStories", storyIds, TimeSpan.FromMinutes(5));
            }
            var pagedIds = storyIds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var tasks = pagedIds.Select(
                id => client.GetFromJsonAsync<StoryDto>($"https://hacker-news.firebaseio.com/v0/item/{id}.json")).ToList();
            var result = await Task.WhenAll(tasks);
            return result.Where(story => !string.IsNullOrEmpty(story?.Url)).ToList();
        }                
    }
}
