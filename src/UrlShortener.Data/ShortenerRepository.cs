using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Domain.Models;

namespace UrlShortener.Data
{
    public class ShortenerRepository : IShortenerRepository
    {
        private readonly DbContextOptions options;
        public ShortenerRepository()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase("shortenerInMemoryDb")
                      .Options;
            
            using (var context = new ApplicationDbContext(options))
            {
                if (context.Links.Count() == 0)
                {
                    var links = new List<LinkEntity>
                                {
                                    new LinkEntity{
                                                      FullValue = "https://www.onet.pl/",
                                                      ShortenValue = "abcde12345"
                                                  },
                                    new LinkEntity{
                                                      FullValue = "https://www.microsoft.com/",
                                                      ShortenValue = "12345abcde"
                                                  }
                                };
                    context.Links.AddRange(links);
                    context.SaveChanges();

                }
            }
        }

        public async Task<LinkEntity> SaveUrl(string fullLink, string shortenLink)
        {
            await using var context = new ApplicationDbContext(options);
            var link = new LinkEntity {FullValue = fullLink, ShortenValue = shortenLink};
            context.Links.Add(link);
            await context.SaveChangesAsync();

            return link;
        }

        public async Task<LinkEntity?> GetUrl(string shortenLink)
        {
            await using var context = new ApplicationDbContext(options);
            var link = await context.Links.SingleOrDefaultAsync(link => link.ShortenValue == shortenLink);

            return link;
        }
    }
}
