using NUnit.Framework;
using SmokeBall.BL;
using SmokeBall.BL.Interfaces;
using System;

namespace SmokeBall.Test
{
    public class GoogleScrapperTest
    {
        private IScrapper scrapper;
        [SetUp]
        public void Setup()
        {
            scrapper = new GoogleScrapper();
            Environment.SetEnvironmentVariable("MaxSearchResultItems", "100");
            Environment.SetEnvironmentVariable("GoogleBaseURL", "https://www.google.com.au");
        }

        [Test]
        public void GetResultForSoftware()
        {
            var result = scrapper.SerachKeywords("Software");
            Assert.GreaterOrEqual(result.Count,2);
        }
    }
}