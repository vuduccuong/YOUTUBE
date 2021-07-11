using DotNetTools.SharpGrabber.Media;
using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YOUTUBE.Services
{
    public interface IYoutubeService
    {
        Task<IEnumerable<SearchResult>> Search(string keyword);

        Task<IEnumerable<GrabbedMedia>> GetVideo(string videoId);
    }
}