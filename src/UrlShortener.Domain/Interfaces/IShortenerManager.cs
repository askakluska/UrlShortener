using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces
{
    public interface IShortenerManager
    {
        Task<Link> ShortenUrl(string link);
        Task<Link?> GetFullUrl(string shortenLink);
        Task<bool> CheckIfUrlAlreadyShortened(string link);
        string CreateShortenUrl(string link);
    }
}
