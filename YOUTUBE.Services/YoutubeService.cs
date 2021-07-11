using DotNetTools.SharpGrabber.Internal.Grabbers;
using DotNetTools.SharpGrabber.Media;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YOUTUBE.Services
{
    public class YoutubeService : IYoutubeService
    {
        public async Task<IEnumerable<SearchResult>> Search(string keyword)
        {
            var YT = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAKer419k8C1BuNamAoCRZEcYYLoyx9LFk",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = YT.Search.List("id,snippet");
            searchListRequest.Q = keyword;
            searchListRequest.MaxResults = 100;
            var searchListResponse = await searchListRequest.ExecuteAsync().ConfigureAwait(false);
            IList<SearchResult> items = searchListResponse.Items;
            return items;
        }

        public async Task<IEnumerable<GrabbedMedia>> GetVideo(string videoId)
        {
            var url = $"https://www.youtube.com/watch?v={videoId}";
            var grabber = new YouTubeGrabber();
            var result = await grabber.GrabAsync(new Uri(url)).ConfigureAwait(false);
            var grabbedResources = result.Resources;
            List<GrabbedMedia> res = new();
            foreach (var item in grabbedResources)
            {
                if (item.GetType().Name.Equals("GrabbedMedia"))
                {
                    res.Add((GrabbedMedia)item);
                }
            }
            return res;
        }
    }
}