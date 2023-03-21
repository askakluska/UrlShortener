namespace UrlShortener.Domain.Models
{
    public class Link
    {
        public Link(string fullValue, string shortenValue)
        {
            this.FullValue = fullValue;
            this.ShortenValue = shortenValue;
        }

        public Link()
        {
        }

        public int Id { get; set; }
        public string FullValue { get; }
        public string ShortenValue { get; }
    }
}
