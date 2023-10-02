using System;
using System.Configuration;
using Azure.Identity;
using BryceResortPatrol.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BryceResortPatrol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    const string keyvaultUriToken = "Config:KeyVaultUri";
                    var config = configApp.Build();
                    var keyVaultUri = config[keyvaultUriToken];
                    if (string.IsNullOrWhiteSpace(keyVaultUri))
                    {
                        throw new ConfigurationErrorsException($"Config value named: {keyvaultUriToken} was not present. Please check config settings.");
                    }

                    configApp.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential(), new DelimiterKeyVaultSecretManager());
                    configApp.Build();
                });
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
    }
}
