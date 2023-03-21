namespace UrlShortener.Domain.Models
{
    public class LinkModel
    {
        public LinkModel(string link)
        {
            Link = link;
        }

        public string Link { get; set; }
    }
}
