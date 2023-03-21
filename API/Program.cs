﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace UrlShortener.API
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel()
                   .UseStartup<Startup>();
    }
}
