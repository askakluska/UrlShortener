namespace UrlShortener.Domain.Business
{
    internal interface IShortenerManager
    {
        Task<string> ShortenLink(string link);
    }
}
