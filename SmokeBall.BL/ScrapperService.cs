using SmokeBall.BL.Interfaces;

namespace SmokeBall.BL
{
    public class ScrapperService : IScrapperService
    {
        private readonly IScrapper _scrapper;
        private readonly IFindMatchItem _findMatchItem;

        public ScrapperService(IScrapper scrapper, IFindMatchItem findMatchItem)
        {
            _scrapper = scrapper;
            _findMatchItem = findMatchItem;
        }
        public List<int> SerachAndFindLinkLoations(string keyWords, string url)
        {
            //1. Search the keywords in google
            var searchResults = _scrapper.SerachKeywords(keyWords);

            //2. Find the locations in which the requested url is found in the result set
            var locations = _findMatchItem.FindLinkLocations(searchResults, url);

            return locations;
        }
    }
}
