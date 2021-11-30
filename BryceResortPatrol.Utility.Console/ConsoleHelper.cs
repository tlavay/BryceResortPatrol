using BryceResortPatrol.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.UtilityConsole
{
    internal static class ConsoleHelper
    {
        public static ServiceProvider GetServiceProvider()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.ConfigureBryceResortPatrolCommon();
            return services.BuildServiceProvider();
        }
    }
}
