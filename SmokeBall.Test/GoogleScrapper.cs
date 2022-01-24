using NUnit.Framework;
using SmokeBall.BL;
using SmokeBall.BL.Interfaces;

namespace SmokeBall.Test
{
    public class GoogleScrapperTest
    {
        private IScrapper scrapper;
        [SetUp]
        public void Setup()
        {
            scrapper = new GoogleScrapper();
        }

        [Test]
        public void GetResultForSoftware()
        {
            var result = scrapper.SerachKeywords("Software");
            Assert.GreaterOrEqual(result.Count,2);
        }
    }
}