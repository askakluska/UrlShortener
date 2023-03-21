namespace UrlShortener.Domain.Entities
{
    public class LinkEntity
    {
        public int Id { get; set; }
        public string FullValue { get; set; }
        public string ShortenValue { get; set; }
    }
}
