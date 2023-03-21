using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Domain.Models;

namespace UrlShortener.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortenerController : ControllerBase
    {
        private readonly IShortenerManager _shortenerManager;

        public ShortenerController(IShortenerManager shortenerManager)
        {
            _shortenerManager = shortenerManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LinkModel url)
        {
            Uri uriResult;
            bool isUrlValid = Uri.TryCreate(url.Link, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!isUrlValid)
            {
                return ValidationProblem("Please provide a valid url.");
            }
            var shortLink = await _shortenerManager.ShortenUrl(url.Link);
            return Ok(shortLink);
        }

        [HttpGet]
        [Route("{shortenLink}")]
        public async Task<IActionResult> Get(string shortenLink)
        {
            var shortLink = await _shortenerManager.GetFullUrl(shortenLink);

            if(shortLink == null)
                return NotFound("Shorten link not found. Please create a new one.");

            return Redirect(shortLink.FullValue);
        }
    }
}