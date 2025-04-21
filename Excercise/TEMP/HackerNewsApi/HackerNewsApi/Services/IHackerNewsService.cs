using HackerNewsApi.Models;

namespace HackerNewsApi.Services
{
    public interface IHackerNewsService
    {
        Task<List<StoryDto>> GetNewestStoriesAsync(int page = 1, int pageSize = 20);
    }
}
