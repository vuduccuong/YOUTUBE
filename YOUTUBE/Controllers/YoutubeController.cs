using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YOUTUBE.Services;

namespace YOUTUBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IYoutubeService _youtubeService;

        public YoutubeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string keyword)
        {
            var data = await _youtubeService.Search(keyword).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> GetDetail(string videoId)
        {
            var detail = await _youtubeService.GetVideo(videoId).ConfigureAwait(false);

            return Ok(detail);
        }
    }
}