using System;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Domain.Models;

namespace UrlShortener.API.Business
{
    public class ShortenerManager : IShortenerManager
    {
        private readonly IShortenerRepository _shortenerRepository;
        private readonly char[] _availableCharacters;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const int ShortenLinkLength = 10;
        private static Random random = new Random();


        public ShortenerManager(IShortenerRepository shortenerRepository)
        {
            _shortenerRepository = shortenerRepository;
            _availableCharacters = (Alphabet + Alphabet.ToLower() + Numbers).ToCharArray();
        }

        public async Task<Link> ShortenUrl(string link)
        {
            if (await CheckIfUrlAlreadyShortened(link))
            {
                var existingLink = await _shortenerRepository.GetUrl(link);
                return new Link(existingLink.FullValue, existingLink.ShortenValue);
            }

            var shortenedLink = CreateShortenUrl(link);
            var newLink = await _shortenerRepository.SaveUrl(link, shortenedLink);
            return new Link(newLink.FullValue, newLink.ShortenValue);
        }

        public async Task<Link?> GetFullUrl(string shortenLink)
        {
            var link = await _shortenerRepository.GetUrl(shortenLink);

            return link != null ? new Link(link.FullValue, link.ShortenValue) : null;
        }

        public async Task<bool> CheckIfUrlAlreadyShortened(string fullLink)
        {
            var link = await _shortenerRepository.GetUrl(fullLink);
            return link != null && link.ShortenValue.Length > 0;
        }

        public string CreateShortenUrl(string link)
        {
            return new string(Enumerable.Repeat(_availableCharacters, ShortenLinkLength)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
