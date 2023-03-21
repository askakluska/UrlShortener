using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Interfaces
{
    public interface IShortenerRepository
    {
        Task<LinkEntity> SaveUrl(string fullLink, string shortenLink);

        Task<LinkEntity?> GetUrl(string shortenLink);
    }
}
