using HackerNewsApi.Models;
using HackerNewsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("controller")]
    public class HackerNewsController : ControllerBase //Controller
    {
        private readonly IHackerNewsService _hackerNewsService;
        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            Console.WriteLine("HackerNewsController created!"); // Add this
            _hackerNewsService = hackerNewsService;
        }
        [HttpGet("newest")]
        [ProducesResponseType(typeof(List<StoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNewestStories(int page = 1, int pageSize = 20)
        {
            var stories = await _hackerNewsService.GetNewestStoriesAsync(page, pageSize);
            return Ok(stories);
        }
    }
}
