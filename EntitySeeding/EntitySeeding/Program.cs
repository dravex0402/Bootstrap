﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using WikiClientLibrary.Client;
using WikiClientLibrary.Sites;

namespace EntitySeeding
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole(LogLevel.Information, true);
            var client = new WikiClient {Logger = loggerFactory.CreateLogger<WikiClient>()};
            var site = new WikiSite(client, "https://crystalpool.cxuesong.com/api.php")
            {
                Logger = loggerFactory.CreateLogger<WikiSite>()
            };
            await site.Initialization;
            await site.LoginAsync(CredentialManager.CpUserName, CredentialManager.CpPassword);
            //await new PopulateBooks(site).RunAsync();
            //await new GatherEntitiesRoutine(site, loggerFactory).RunAsync();
            //await new PopulateBookInfo1Routine(site, loggerFactory).RunAsync();
            //new PopulateEditionsRoutine(site, loggerFactory, "zh-tw").PrintEntities();
            //await new PopulateEditionsRoutine(site, loggerFactory, "zh-tw").RunAsync();
            //await new PopulateChapters(site, loggerFactory).RunAsync();
            await new PopulateCats(site, loggerFactory).RunAsync();
        }
    }
}
