using Moq;
using NUnit.Framework;
using SmokeBall.BL;
using SmokeBall.BL.Interfaces;
using System.Collections.Generic;

namespace SmokeBall.Test
{
    public class ServiceScrapper
    {
        private IScrapperService scrapperService;
        [SetUp]
        public void Setup()
        {
            var mockScrapper = new Mock<IScrapper>();
            var findMatchItem = new FindMatchItem();

            var searchResult = new List<string>();
            searchResult.Add("www.sampleurl1.com.au");
            searchResult.Add("www.sampleurl2.com.au");
            searchResult.Add("www.sampleurl3.com.au");
            searchResult.Add("www.sampleurl4.com.au");
            searchResult.Add("www.expected.com.au");
            searchResult.Add("www.sampleurl5.com.au");
            searchResult.Add("www.sampleurl6.com.au");
            searchResult.Add("www.expected.com.au");

            mockScrapper.Setup(x => x.SerachKeywords(It.IsAny<string>())).Returns(searchResult);

            scrapperService = new ScrapperService(mockScrapper.Object, findMatchItem);
        }

        [Test]
        public void GetMultimpleResultFromScrapperServiceTest()
        {
            var actual = scrapperService.SerachAndFindLinkLoations("expected", "www.expected.com.au");

            var expected = new List<int>() { 5, 8 };

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetSingleResultFromScrapperServiceTest()
        {
            var actual = scrapperService.SerachAndFindLinkLoations("expected", "www.sampleurl1.com.au");

            var expected = new List<int>() { 1 };

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetNoneResultFromScrapperServiceTest()
        {
            var actual = scrapperService.SerachAndFindLinkLoations("expected", "www.none.com.au");

            var expected = new List<int>() {};

            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}