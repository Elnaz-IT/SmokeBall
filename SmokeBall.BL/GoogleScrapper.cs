using SmokeBall.BL.Interfaces;
using SmokeBall.Helpers;
using System.Net;

namespace SmokeBall.BL
{
    public class GoogleScrapper : IScrapper
    {
        public List<string> SerachKeywords(string keyWords)
        {
            try
            {
                var searchResults = new List<string>();
                var web = new WebClient();

                var serachUrl = $"{ConfigurationSettings.GoogleBaseURL}/search?q=" + keyWords.Replace(' ', '+');

                while (searchResults.Count < ConfigurationSettings.MaxSearchResultItems)
                {
                    var htmlResult = web.DownloadString(serachUrl);
                    var searchResult = LinkExtractor.ExtractLinks(htmlResult);
                    searchResults.AddRange(searchResult);
                    serachUrl = LinkExtractor.ExtractSpecialLink(htmlResult);
                }

                return searchResults;
            }
            catch (Exception ex)
            {
                //TODO logger
                //Logger.Log(ex);
                throw;
            }
        }

    }
}