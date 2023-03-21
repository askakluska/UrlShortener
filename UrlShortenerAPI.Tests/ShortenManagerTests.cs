using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UrlShortener.API.Business;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Interfaces;

namespace UrlShortenerAPI.Tests
{
    public class ShortenManagerTests
    {
        private ShortenerManager? _shortenerManager;

        [SetUp]
        public void Setup()
        {
            var mockRepository = new Mock<IShortenerRepository>();
            _shortenerManager = new ShortenerManager(mockRepository.Object);
        }

        [Test]
        public async Task ShortenUrl_Returns_New_Shortened_Link_When_Not_Already_Shortened()
        {
            var fullLink = "http://www.example.com";
            var mockLink = new LinkEntity {FullValue = fullLink, ShortenValue = "abc123"};
            var mockRepository = new Mock<IShortenerRepository>();
            mockRepository.Setup(sr => sr.GetUrl(fullLink)).ReturnsAsync((LinkEntity) null);
            mockRepository.Setup(sr => sr.SaveUrl(fullLink, It.IsAny<string>())).ReturnsAsync(mockLink);
            _shortenerManager = new ShortenerManager(mockRepository.Object);
            
            var result = await _shortenerManager.ShortenUrl(fullLink);
            
            Assert.AreEqual(mockLink.ShortenValue, result.ShortenValue);
        }

        [Test]
        public async Task ShortenUrl_Returns_Existing_Shortened_Link_When_Already_Shortened()
        {
            var fullLink = "http://www.example.com";
            var mockLink = new LinkEntity { FullValue = fullLink, ShortenValue = "ShortenLink"};
            var mockRepository = new Mock<IShortenerRepository>();
            mockRepository.Setup(sr => sr.GetUrl(fullLink)).ReturnsAsync(mockLink);
            _shortenerManager = new ShortenerManager(mockRepository.Object);

            var result = await _shortenerManager.ShortenUrl(fullLink);

            Assert.AreEqual(mockLink.ShortenValue, result.ShortenValue);
      }

        [Test]
        public async Task CheckIfUrlAlreadyShortened_Returns_True_If_Link_Is_Already_Shortened()
        {
            var fullLink = "http://www.example.com";
            var mockLink = new LinkEntity { FullValue = fullLink, ShortenValue = "ShortenLink"};
            var mockRepository = new Mock<IShortenerRepository>();
            mockRepository.Setup(sr => sr.GetUrl(fullLink)).ReturnsAsync(mockLink);
            _shortenerManager = new ShortenerManager(mockRepository.Object);

            var result = await _shortenerManager.CheckIfUrlAlreadyShortened(fullLink);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckIfUrlAlreadyShortened_Returns_False_If_Link_Is_Not_Shortened()
        {
            var fullLink = "http://www.example.com";
            var mockRepository = new Mock<IShortenerRepository>();
            _shortenerManager = new ShortenerManager(mockRepository.Object);

            var result = await _shortenerManager.CheckIfUrlAlreadyShortened(fullLink);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetFullUrl_Returns_Link_With_Given_Shortened_Link()
        {
            var shortenLink = "ShortenLink";
            var mockLink = new LinkEntity { FullValue = "http://www.example.com", ShortenValue = shortenLink };
            var mockRepository = new Mock<IShortenerRepository>();
            mockRepository.Setup(sr => sr.GetUrl(shortenLink)).ReturnsAsync(mockLink);
            _shortenerManager = new ShortenerManager(mockRepository.Object);
            
            var result = await _shortenerManager.GetFullUrl(shortenLink);
            
            Assert.AreEqual(mockLink.FullValue, result.FullValue);
        }
    }
}